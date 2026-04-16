using System;
using System.Net;
using System.Net.Http;

namespace Namoo.Client
{
    /// <summary>
    /// NaRouterWorkDo 기반 서버 호출용 <see cref="HttpClient"/>.
    /// <c>Set-Cookie: NAMOO_SESSION=…; HttpOnly</c> 를 저장해 이후 <c>/doWork</c>, <c>/progress</c>, <c>/cancelWork</c> 요청에 자동 전송한다 (WinForms 는 브라우저와 달리 쿠키 저장소를 직접 붙여야 함).
    /// </summary>
    public static class NamooServerHttp
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
    }
}
