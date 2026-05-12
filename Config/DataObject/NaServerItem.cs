namespace Namoo.Client.Config.DataObject
{
    public sealed class NaServerItem
    {
        public int Seq { get; set; }

        public string Name { get; set; } = "";

        public string Url { get; set; } = "";

        public string ApiKey { get; set; } = "";

        /// <summary>엔드포인트는 서버별로 키가 다를 수 있어 IDictionary 로 수용합니다.</summary>
        public NaEndPoints Endpoints { get; set; } = new();
    }
}
