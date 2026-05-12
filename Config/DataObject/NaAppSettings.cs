namespace Namoo.Client.Config.DataObject;

/// <summary><c>appsettings*.json</c> 의 <c>App</c> 섹션에 대응하는 모델.</summary>
public sealed class NaAppSettings
{
    public string ApplicationName { get; set; } = "";

    public string CurrentServerName { get; set; } = "";

    /// <summary>비어 있으면 시스템 기본 문화를 사용합니다.</summary>
    public string Culture { get; set; } = "";
}
