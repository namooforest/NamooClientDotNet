using System.Collections.Generic;

namespace Namoo.Client.Config.DataObject;

/// <summary>현재 환경의 <c>appsettings.{env}.json</c> 오버레이 파일과 동일한 구조(직렬화/역직렬화용).</summary>
public sealed class NaConfigRoot
{
    public NaAppSettings App { get; set; } = new();

    public List<NaServerItem> ServerList { get; set; } = [];
}
