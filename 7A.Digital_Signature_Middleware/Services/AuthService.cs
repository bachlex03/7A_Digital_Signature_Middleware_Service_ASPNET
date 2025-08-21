using _7A.Digital_Signature_Middleware.Abstractions;
using _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory;
using _7A.Digital_Signature_Middleware.Settings;
using Microsoft.Extensions.Options;

namespace _7A.Digital_Signature_Middleware.Services;

public class AuthService : IAuthService
{
    private readonly string _url;
    private readonly string _relyingParty;
    private readonly string _relyingPartyUser;
    private readonly string _relyingPartyPassword;
    private readonly string _relyingPartySignature;
    private readonly string _relyingPartyKeyStore;
    private readonly string _relyingPartyKeyStorePassword;

    public static IServerSession session;

    public AuthService(IOptions<SslThirdPartySettings> sslThirdPartySettings)
    {
        this._url = sslThirdPartySettings.Value.Url ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.Url));
        this._relyingParty = sslThirdPartySettings.Value.RelyingParty ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingParty));
        this._relyingPartyUser = sslThirdPartySettings.Value.RelyingPartyUser ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingPartyUser));
        this._relyingPartyPassword = sslThirdPartySettings.Value.RelyingPartyPassword ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingPartyPassword));
        this._relyingPartySignature = sslThirdPartySettings.Value.RelyingPartySignature ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingPartySignature));
        this._relyingPartyKeyStore = sslThirdPartySettings.Value.RelyingPartyKeyStore ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingPartyKeyStore));
        this._relyingPartyKeyStorePassword = sslThirdPartySettings.Value.RelyingPartyKeyStorePassword ?? throw new ArgumentNullException(nameof(sslThirdPartySettings.Value.RelyingPartyKeyStorePassword));
    
        Console.WriteLine("AuthService initialized with URL: " + this._url);
        Console.WriteLine("Relying Party: " + this._relyingParty);
        Console.WriteLine("Relying Party User: " + this._relyingPartyUser);
        Console.WriteLine("Relying Party Password: " + this._relyingPartyPassword);
        Console.WriteLine("Relying Party Signature: " + this._relyingPartySignature);
        Console.WriteLine("Relying Party Key Store: " + this._relyingPartyKeyStore);
        Console.WriteLine("Relying Party Key Store Password: " + this._relyingPartyKeyStorePassword);
    }

    public string Login(string username, string password)
    {
        Property property = new Property(this._url,
                                         this._relyingParty,
                                         this._relyingPartyUser,
                                         this._relyingPartyPassword,
                                         this._relyingPartySignature,
                                         this._relyingPartyKeyStore,
                                         this._relyingPartyKeyStorePassword);

        SessionFactory factory = new SessionFactory(property, "VN", username, password);    //Init SessionFactory

        IServerSession session = factory.getServerSession();

        return "";
    }
}
