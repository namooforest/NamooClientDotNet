using Microsoft.Extensions.Configuration;
using Namoo.Client.Config.DataObject;
using Namoo.Client.Forms;
using Namoo.Frame;
using Namoo.Frame.DataObject.DTO;
using Namoo.Frame.Message;
using Namoo.Frame.NaExceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Namoo.Client.Config
{
    public static class NaClientConfig
    {
        public static NaEndPoints EndPoints { get; set; } = new NaEndPoints();

        private static NaConnector _defaultConnector = null;
        private static NaConnector _frameWorkConnector = null;
        private static List<NaConnector> _liConnector = null;
        private static string UserId = null;

        #region ▼▼▼ appsettings.json Start ▼▼▼
        static IConfigurationRoot _root;
        /// <exception cref="InvalidOperationException"><see cref="Initialize"/> 호출 전에 접근한 경우.</exception>
        public static IConfiguration Configuration =>
            _root ?? throw new InvalidOperationException("NaClientConfig.Initialize()를 Program.Main에서 먼저 호출하세요.");
        /// <summary>네임스페이스 접근까지 포함한 현재 설정의 <c>App</c> 구간 바인딩 결과 (<see cref="RefreshBoundSections"/> 시 갱신).</summary>
        public static NaAppSettings App { get; private set; } = new();

        private static string _configurationBasePath = "";

        /// <summary>
        /// 활성 실행 환경 이름 (예: <c>Production</c>, <c>Development</c>, <c>Local</c>).
        /// <see cref="Initialize"/> 과 오버레이 파일명 <c>appsettings.{env}.json</c> 에 동일하게 사용합니다.
        /// </summary>
        public static string GetEffectiveEnvironment()
        {
            return Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";
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

            ReloadConfigurationState();
        }

        public static void GetInitDataFromServer() {
            // 향후 로그인이나 다른 곳에서 가져오도록 수정해야 할 듯?
            UserId = NaFrameConfig.UserId;
            // 서버에서 클라이언트 설정 정보 가져오기
            NaBaseFormHelper helper = new NaBaseFormHelper();
            NaWorkerReq req = new NaWorkerReq("Namoo.GetClientConfig");
            NaWorkerRes res = helper.CallWorker(req);
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
            ReloadConfigurationState();
        }

        static void ReloadConfigurationState()
        {
            RefreshBoundSections();
        }

        /// <summary><c>App</c> 등 메모리에 유지하는 바인딩 객체만 <see cref="Configuration"/> 기준으로 다시 채웁니다.</summary>
        public static void RefreshBoundSections()
        {
            App = Configuration.GetSection("App").Get<NaAppSettings>() ?? new NaAppSettings();
        }

        /// <summary><c>ServerList</c> 배열 바인딩.</summary>
        public static List<NaServerItem> GetServerList() =>
            Configuration.GetSection("ServerList").Get<List<NaServerItem>>() ?? [];

        public static string DoWorkEndpoint => GetCurrentServer()?.Endpoints.DoWork;

        public static string ProgressEndpoint => GetCurrentServer()?.Endpoints.Progress;

        public static string CancelWorkEndpoint => GetCurrentServer()?.Endpoints.CancelWork;

        public static NaServerItem GetCurrentServer()
        {
            string sServerName = App.CurrentServerName;
            if (string.IsNullOrEmpty(sServerName))
                return null;

            return GetServerList().FirstOrDefault(s => s.Name == sServerName);
        }

        /// <summary><c>Configuration.Bind</c> 또는 키 인덱싱 전에 구간 노드를 반환합니다.</summary>
        public static IConfigurationSection GetSection(string key) => Configuration.GetSection(key);

        /// <summary><paramref name="sectionName"/> 구간을 <typeparamref name="T"/> 로 바인딩합니다.</summary>
        public static T GetSection<T>(string sectionName) where T : class, new() =>
            Configuration.GetSection(sectionName).Get<T>() ?? new T();

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
            WriteIndented = true
        };

        public static NaConfigRoot LoadOverlayDocument()
        {
            var path = GetOverlaySettingsFilePath();
            if (!File.Exists(path))
                return new NaConfigRoot();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<NaConfigRoot>(json, ReadOptions) ?? new NaConfigRoot();
        }

        /// <summary>
        /// 오버레이 JSON 파일(<c>appsettings.{현재환경}.json</c>)에 원자적으로 저장 후 <see cref="Reload"/> 합니다.
        /// </summary>
        public static void SaveOverlayDocument(NaConfigRoot root)
        {
            if (root == null)
                throw new ArgumentNullException(nameof(root));

            var path = GetOverlaySettingsFilePath();
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var tmp = path + ".tmp";
            var json = JsonSerializer.Serialize(root, WriteOptions);
            File.WriteAllText(tmp, json);

            if (File.Exists(path))
                File.Replace(tmp, path, destinationBackupFileName: null);
            else
                File.Move(tmp, path);

            Reload();
        }

        #endregion ▲▲▲ appsettings.json End ▲▲▲
        
        #region ▼▼▼ Connector Start ▼▼▼
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
        #endregion ▲▲▲ Connector End ▲▲▲
    }
}
