namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory.Requests;

class LoginRequest : Request
{
    public String relyingParty { get; set; } = "";
    public bool rememberMeEnabled { get; set; }
}
