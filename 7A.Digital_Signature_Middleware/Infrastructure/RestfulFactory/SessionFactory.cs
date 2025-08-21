using _7A.Digital_Signature_Middleware.Abstractions;

namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory;

public class SessionFactory : ISessionFactory
{
    private Property prop;
    private string lang;
    private string username;
    private string password;

    public SessionFactory(Property prop, string lang, string username, string password)
    {
        this.prop = prop;
        this.lang = lang;
        this.username = username;
        this.password = password;
    }

    public IServerSession getServerSession()
    {
        ServerSession serverSession = new ServerSession(this.prop, this.lang, this.username, this.password);

        return serverSession;
    }
}
