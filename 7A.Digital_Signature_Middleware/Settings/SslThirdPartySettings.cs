namespace _7A.Digital_Signature_Middleware.Settings;

public class SslThirdPartySettings
{
     public const string SettingKey = "SslThirdPartySettings";

    public string? Url { get; set; }
    public string? RelyingParty { get; set; }
    public string? RelyingPartyUser { get; set; }
    public string? RelyingPartyPassword { get; set; }
    public string? RelyingPartySignature { get; set; }
    public string? RelyingPartyKeyStore { get; set; }
    public string? RelyingPartyKeyStorePassword { get; set; }
}
