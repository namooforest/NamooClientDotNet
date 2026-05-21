using DevExpress.CodeParser;
using Microsoft.Extensions.Configuration;
using Namoo.Client.Config.DataObject;
using Namoo.Client.Worker;
using Namoo.Frame;
using Namoo.Frame.DataObject.DTO;
using Namoo.Frame.Function;
using Namoo.Frame.Message;
using Namoo.Frame.NaExceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Namoo.Client.Config
{
    public static class NaClientConfig
    {
        public static NaServerItem Server { get; set; }
        public static NaSession SessionInfo { get; set; }

        private static NaConnector _defaultConnector = null;
        private static NaConnector _frameWorkConnector = null;
        private static List<NaConnector> _liConnector = null;
        private static string UserId = null;
        private static string _sAppSection = "App";
        private static string _sServerListSection = "ServerList";

        #region ▼▼▼ IConfiguration ▼▼▼
        static IConfigurationRoot _root;
        
        /// <exception cref="InvalidOperationException"><see cref="Initialize"/> 호출 전에 접근한 경우.</exception>
        public static IConfiguration Configuration => _root ?? throw new InvalidOperationException("NaClientConfig.Initialize()를 Program.Main에서 먼저 호출하세요.");

        /// <summary><c>Configuration.Bind</c> 또는 키 인덱싱 전에 구간 노드를 반환합니다.</summary>
        public static IConfigurationSection GetSection(string key) => Configuration.GetSection(key);

        /// <summary><paramref name="sectionName"/> 구간을 <typeparamref name="T"/> 로 바인딩합니다.</summary>
        public static T GetSection<T>(string sectionName) where T : class, new() => Configuration.GetSection(sectionName).Get<T>() ?? new T();
        #endregion ▲▲▲ IConfiguration ▲▲▲

        #region ▼▼▼ Uri ▼▼▼
        public static Uri GetDoWorkUri()
        {
            string sUrl = NaFunctions.CombineUrl(NaClientConfig.Server.Url, NaClientConfig.Server.Endpoints.DoWork);
            return new Uri(sUrl);
        }

        public static Uri GetProgressUri()
        {
            string sUrl = NaFunctions.CombineUrl(NaClientConfig.Server.Url, NaClientConfig.Server.Endpoints.Progress);
            return new Uri(sUrl);
        }
        
        public static Uri GetCancelWorkUri()
        {
            string sUrl = NaFunctions.CombineUrl(NaClientConfig.Server.Url, NaClientConfig.Server.Endpoints.CancelWork);
            return new Uri(sUrl);
        }
        #endregion ▲▲▲ Uri ▲▲▲

        #region ▼▼▼ appsettings.json ▼▼▼

        /// <summary>네임스페이스 접근까지 포함한 현재 설정의 <c>App</c> 구간 바인딩 결과 (<see cref="RefreshBoundSections"/> 시 갱신).</summary>
        public static NaAppSettings App { get; private set; } = new();

        private static string _configurationBasePath = "";

        /// <summary>
        /// 활성 실행 환경 이름 (예: <c>Production</c>, <c>Development</c>, <c>Local</c>).
        /// <see cref="Initialize"/> 과 오버레이 파일명 <c>appsettings.{env}.json</c> 에 동일하게 사용합니다.
        /// </summary>
        public static string GetEffectiveEnvironment()
        {
            return Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        }

        /// <summary><paramref name="basePath"/> 기준으로 <c>appsettings.json</c> 및 <c>appsettings.{환경}.json</c> 만 로드합니다.</summary>
        public static void Initialize(string basePath)
        {
            string env = GetEffectiveEnvironment();
            _configurationBasePath = basePath.TrimEnd(Path.DirectorySeparatorChar);

            _root = new ConfigurationBuilder()
                .SetBasePath(_configurationBasePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .Build();

            RefreshBoundSections();
        }

        /// <summary>
        /// 서버로부터 초기 설정 데이터를 가져옵니다.
        /// </summary>
        /// <exception cref="NaException"></exception>
        public static void GetInitDataFromServer() {
            // 향후 로그인이나 다른 곳에서 가져오도록 수정해야 할 듯?
            UserId = NaFrameConfig.UserId;
            // 서버에서 클라이언트 설정 정보 가져오기
            NaWorkerReq req = new NaWorkerReq("Namoo.GetClientConfig");
            NaWorkerRes res = NaCall.Worker(req);
            if (res.IsSuccess == false)
                throw new NaException(res.Message, res.Exception);

            // Connector List
            // Client에서는 이름 정보 외에는 필요 없음.
            _liConnector = res.GetResponseData<List<NaConnector>>("CONNECTOR_LIST");
            _defaultConnector = res.GetResponseData<NaConnector>("DEFAULT_CONNECTOR");
            _frameWorkConnector = res.GetResponseData<NaConnector>("FRAMEWORK_CONNECTOR");
        }

        /// <summary>디스크의 JSON 변경을 다시 읽고 <see cref="App"/> 및 서버별 엔드포인트 캐시를 갱신합니다.</summary>
        public static void Reload()
        {
            _root?.Reload();
            RefreshBoundSections();
        }

        /// <summary><c>App</c> 등 메모리에 유지하는 바인딩 객체만 <see cref="Configuration"/> 기준으로 다시 채웁니다.</summary>
        public static void RefreshBoundSections()
        {
            App = Configuration.GetSection(_sAppSection).Get<NaAppSettings>() ?? new NaAppSettings();
            Server = GetCurrentServer();
        }

        /// <summary><c>ServerList</c> 배열 바인딩.</summary>
        public static List<NaServerItem> GetServerList() => Configuration.GetSection(_sServerListSection).Get<List<NaServerItem>>() ?? [];

        public static NaServerItem GetCurrentServer()
        {
            string sServerName = App.CurrentServerName?.Trim();
            if (string.IsNullOrEmpty(sServerName))
                return null;

            return GetServerList().FirstOrDefault(s => s.Name == sServerName);
        }



        /// <summary>현재 환경에 대응하는 <c>appsettings.{env}.json</c> 파일의 전체 경로입니다.</summary>
        public static string GetOverlaySettingsFilePath()
        {
            string baseDir =
                string.IsNullOrEmpty(_configurationBasePath)
                    ? AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar)
                    : _configurationBasePath;
            return Path.Combine(baseDir, $"appsettings.{GetEffectiveEnvironment()}.json");
        }

        private static JsonSerializerOptions ReadOptions => new()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        private static JsonSerializerOptions WriteOptions => new()
        {
            WriteIndented = true,
            // 기본값은 한글 등을 \\uXXXX 로 이스케이프함 — 사람이 읽는 appsettings 에는 문자 그대로 쓴다.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary><see cref="Save"/>·목록 복제용(들여쓰기 없음).</summary>
        static readonly JsonSerializerOptions SerializerCopyOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = false
        };

        static bool ServerListContainsIdentity(IReadOnlyList<NaServerItem> list, NaServerItem candidate)
        {
            foreach (var row in list)
            {
                if (ServerIdentityEquals(row, candidate))
                    return true;
            }
            return false;
        }

        static bool ServerIdentityEquals(NaServerItem a, NaServerItem b)
        {
            if (a == null || b == null)
                return false;
            bool aHasName = !string.IsNullOrWhiteSpace(a.Name);
            bool bHasName = !string.IsNullOrWhiteSpace(b.Name);
            if (aHasName && bHasName)
                return string.Equals(a.Name.Trim(), b.Name.Trim(), StringComparison.OrdinalIgnoreCase);
            return string.Equals(a.Url?.Trim(), b.Url?.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 캐시된 Config를 파일로 저장 후 Reload 합니다.
        /// </summary>
        public static void Save()
        {
            var path = GetOverlaySettingsFilePath();
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var snapshot = new NaConfigRoot
            {
                App = App,
                ServerList = GetServerList(),
            };

            var tmp = path + ".tmp";
            var json = JsonSerializer.Serialize(snapshot, WriteOptions);
            File.WriteAllText(tmp, json);

            if (File.Exists(path))
                File.Replace(tmp, path, destinationBackupFileName: null);
            else
                File.Move(tmp, path);

            Reload();
        }
        #endregion ▲▲▲ appsettings.json ▲▲▲
        
        #region ▼▼▼ Connector ▼▼▼
        public static List<NaConnector> GetConnectorList()
        {
            if (_liConnector == null)
                throw new NaException("클라이언트 설정이 초기화되지 않았습니다.");
            return _liConnector;
        }

        public static NaConnector GetConnector(string sConnectorName)
        {
            if (_liConnector == null)
                throw new NaException("클라이언트 설정이 초기화되지 않았습니다.");
            return _liConnector.Find(conn => conn.ConnectorName == sConnectorName);
        }

        public static NaConnector GetDefaultConnector()
        {
            if (_defaultConnector == null)
                throw new NaException("클라이언트 설정이 초기화되지 않았습니다.");
            return _defaultConnector;
        }

        public static NaConnector GetFrameworkConnector()
        {
            if (_frameWorkConnector == null)
                throw new NaException("클라이언트 설정이 초기화되지 않았습니다.");
            return _frameWorkConnector;
        }
        #endregion ▲▲▲ Connector ▲▲▲
    }
}
