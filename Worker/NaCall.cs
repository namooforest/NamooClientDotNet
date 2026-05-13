using Namoo.Client.Config;
using Namoo.Frame;
using Namoo.Frame.DataObject.DTO;
using Namoo.Frame.Logger;
using Namoo.Frame.Message;
using Namoo.Frame.NaExceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Namoo.Client.Worker;

public static class NaCall
{
    private static readonly HttpClientHandler Handler = new HttpClientHandler
    {
        UseCookies = true,
        CookieContainer = new CookieContainer(),
    };

    /// <summary>프로세스 전역에서 재사용. 동시에 여러 ProgressForm 이 호출해도 스레드 안전.</summary>
    public static readonly HttpClient Client = new HttpClient(Handler, disposeHandler: false)
    {
        Timeout = TimeSpan.FromHours(24),
    };

    public static NaWorkerRes Login(string sUserId, string sPassword, CancellationToken cancellationToken = default)
    {
        var dic = new Dictionary<string, object>
        {
            ["UserId"] = sUserId?.Trim() ?? "",
            ["Password"] = sPassword ?? "",
            ["LangTag"] = System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag ?? ""
        };

        var req = new NaWorkerReq("Namoo.Login", dic);

        return HelloServer(true, GetDoWorkUri(), req, cancellationToken).GetAwaiter().GetResult();
    }

    public static NaWorkerRes LoginApiKey(string sApiKey, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(sApiKey))
            sApiKey = NaClientConfig.Server.ApiKey;
        if (string.IsNullOrEmpty(sApiKey))
            throw new Exception("API 키가 설정되어 있지 않습니다.");

        Dictionary<string, object> requestData = new Dictionary<string, object>
            {
                { "API_KEY", sApiKey }
            };
        NaWorkerReq req = new NaWorkerReq(NaConst.WorkerName.LoginApiKey, requestData);
        NaWorkerRes res = Worker(req);
        if (res.IsSuccess == false)
        {
            NaClientConfig.SessionInfo = new NaSession();
            throw new Exception(res.Message ?? "API 키 로그인에 실패했습니다.");
        }

        string sSessionId = res.GetResponseData<string>("SessionId");
        Dictionary<string, object> dicUserInfo = res.GetResponseData<Dictionary<string, object>>("User");

        NaSession session = new NaSession();
        session.SessionId = sSessionId;
        session.UserSystemId = Convert.ToString(dicUserInfo["UserSystemId"]);
        session.UserId = Convert.ToString(dicUserInfo["UserId"]);
        session.LangTag = Convert.ToString(dicUserInfo["LangTag"]);

        NaClientConfig.SessionInfo = session;

        return res;
    }

    /// <summary>
    /// 일반 워커 이외의 호출이 필요한 경우(GET)
    /// </summary>
    /// <returns></returns>
    public static NaWorkerRes AnyGet(Uri uri, NaWorkerReq req, CancellationToken cancellationToken = default)
    {
        return HelloServer(false, uri, req, cancellationToken).GetAwaiter().GetResult();
    }

    /// <summary>
    /// 일반 워커 이외의 호출이 필요한 경우(POST)
    /// </summary>
    /// <returns></returns>
    public static NaWorkerRes AnyPost(Uri uri, NaWorkerReq req, CancellationToken cancellationToken = default)
    {
        return HelloServer(true,uri, req, cancellationToken).GetAwaiter().GetResult();
    }

    private static async Task<NaWorkerRes> HelloServer(bool isPost, Uri uri, NaWorkerReq req, CancellationToken cancellationToken = default)
    {
        using var request = isPost
            ? new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(
                    NaFunctions.ConvertObjectToJsonString(req),
                    Encoding.UTF8,
                    "application/json"),
            }
            : new HttpRequestMessage(HttpMethod.Get, uri);

        AppendOptionalAuthHeaders(request);

        using HttpResponseMessage response =
            await Client.SendAsync(request, cancellationToken).ConfigureAwait(true);

        response.EnsureSuccessStatusCode();
        string body = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
        return NaFunctions.ConvertJsonStringToObject<NaWorkerRes>(body);
    }

    /// <summary>
    /// Worker 호출용 동기 메서드
    /// </summary>
    public static NaWorkerRes Worker(NaWorkerReq req, CancellationToken cancellationToken = default)
    {
        try
        {
            return WorkerAsync(req, cancellationToken).GetAwaiter().GetResult();
        }
        catch (OperationCanceledException oce)
        {
            var r = Fail(req, oce);
            r.Message = "작업이 취소되었습니다.";
            return r;
        }
        catch (Exception ex)
        {
            return Fail(req, ex);
        }
    }

    /// <summary>
    /// <see cref="ProgressForm"/> 과 동일하게 JSON 직렬화 후 POST하고 <see cref="NaWorkerRes"/> 로 역직렬화합니다 (폴링 없음).
    /// </summary>
    /// <exception cref="ArgumentNullException"><paramref name="req"/> 가 null 입니다.</exception>
    /// <exception cref="OperationCanceledException"><paramref name="cancellationToken"/> 또는 요청 중 취소.</exception>
    public static async Task<NaWorkerRes> WorkerAsync(NaWorkerReq req, CancellationToken cancellationToken = default)
    {
        if (req == null)
            throw new ArgumentNullException(nameof(req));

        string sJsonMsg = NaFunctions.ConvertObjectToJsonString(req);
        NaLogger.Logger(LogLevel.DEBUG, req.WorkerName, sJsonMsg);

        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, GetDoWorkUri())
            {
                Content = new StringContent(sJsonMsg, Encoding.UTF8, "application/json"),
            };
            AppendOptionalAuthHeaders(request);

            using HttpResponseMessage response =
                await Client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string sReturn = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrEmpty(sReturn))
                throw new InvalidOperationException("응답 데이터가 없습니다.");

            var wResponse = NaFunctions.ConvertJsonStringToObject<NaWorkerRes>(sReturn);

            NaLogger.Logger(LogLevel.DEBUG, req.WorkerName, NaFunctions.ConvertObjectToJsonString(wResponse));
            return wResponse ?? Fail(req, new InvalidOperationException("응답 파싱 결과가 비어 있습니다."));
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            NaLogger.Logger(LogLevel.ERROR, req.WorkerName, ex.ToString());
            return Fail(req, ex);
        }
    }

    static NaWorkerRes Fail(NaWorkerReq req, Exception ex)
    {
        var res = req != null ? new NaWorkerRes(req) : new NaWorkerRes();
        res.IsSuccess = false;
        res.Message = string.IsNullOrWhiteSpace(ex?.Message)
            ? (ex?.ToString() ?? "알 수 없는 오류")
            : ex.Message;
        try
        {
            res.Exception = ex != null ? new NaException(ex) : null;
        }
        catch
        {
            res.Exception = null;
        }

        return res;
    }

    private static Uri GetDoWorkUri()
    {
        string sUrl = NaFunctions.CombineUrl(NaClientConfig.Server.Url, NaClientConfig.Server.Endpoints.DoWork);
        return new Uri(sUrl);
    }

    private static void AppendOptionalAuthHeaders(HttpRequestMessage request)
    {
        if (request == null)
            return;

        string apiKey = NaClientConfig.Server?.ApiKey;
        if (!string.IsNullOrWhiteSpace(apiKey))
            request.Headers.TryAddWithoutValidation(NaConst.HttpHeader.HeaderApiKey, apiKey);

        string sessionId = NaClientConfig.SessionInfo?.SessionId;
        if (!string.IsNullOrWhiteSpace(sessionId))
            request.Headers.TryAddWithoutValidation(NaConst.HttpHeader.HeaderSessionId, sessionId);
    }
}
