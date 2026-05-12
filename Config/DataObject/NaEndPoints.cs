namespace Namoo.Client.Config.DataObject
{
    public class NaEndPoints
    {
        public string DoWork { get; set; } = "/doWork";
        public string Progress { get; set; } = "/progress";
        public string CancelWork { get; set; } = "/cancelWork";
        
        public string LoginApiKey { get; set; } = "/user/apiKeyLogin";
        public string UserLogin { get; set; } = "/user/login";
        public string UserLogout { get; set; } = "/user/logout";
        public string UserSignup { get; set; } = "/user/signup";
        public string SessionRestore { get; set; } = "/user/restore";

        public string FileDownload { get; set; } = "/fileDownload";
        public string FileUpload { get; set; } = "/fileUpload";
    }
}
