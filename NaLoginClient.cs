using Namoo.Frame;
using Namoo.Frame.Message;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Namoo.Client
{
    /// <summary>세션 쿠키(<c>NAMOO_SESSION</c>)를 유지하는 <see cref="NamooServerHttp.Client"/>로 <c>Namoo.Login</c> 호출.</summary>
    public static class NaLoginClient
    {
        public static async Task<NaWorkerRes> TryLoginAsync(string userId, string password, CancellationToken cancellationToken = default)
        {
            var dic = new Dictionary<string, object>
            {
                ["UserId"] = userId?.Trim() ?? "",
                ["Password"] = password ?? "",
                ["LangTag"] = System.Globalization.CultureInfo.CurrentUICulture.IetfLanguageTag ?? ""
            };
            var req = new NaWorkerReq("Namoo.Login", dic);
            string json = NaFunctions.ConvertObjectToJsonString(req);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await NamooServerHttp.Client.PostAsync(NaClientConfig.DoWorkEndpoint, content, cancellationToken).ConfigureAwait(true);
            response.EnsureSuccessStatusCode();
            string body = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            return NaFunctions.ConvertJsonStringToObject<NaWorkerRes>(body);
        }
    }
}
