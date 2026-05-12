using Namoo.Client.Forms;
using Namoo.Frame;
using Namoo.Frame.DataObject.DTO;
using Namoo.Frame.Message;
using Namoo.Frame.NaExceptions;
using System.Collections.Generic;

namespace Namoo.Client
{
    public static class NaClientConfig
    {
        public static string DoWorkEndpoint { get; set; } = "/doWork";
        public static string ProgressEndpoint { get; set; } = "/progress";
        public static string CancelWorkEndpoint { get; set; } = "/cancelWork";
        public static string LoginEndpoint { get; set; } = "/user/apiKeyLogin";

        private static NaConnector _defaultConnector = null;
        private static NaConnector _frameWorkConnector = null;
        private static List<NaConnector> _liConnector = null;
        private static string UserId = null;

        public static void Initialize()
        {
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
