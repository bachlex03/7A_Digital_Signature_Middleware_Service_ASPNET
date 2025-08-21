using _7A.Digital_Signature_Middleware.Abstractions;
using _7A.Digital_Signature_Middleware.Settings;
using Microsoft.Extensions.Options;

namespace _7A.Digital_Signature_Middleware.Services;

public class AuthService : IAuthService
{
    public AuthService(IOptions<SslThirdPartySettings> sslThirdPartySettings)
    {

    }
}
