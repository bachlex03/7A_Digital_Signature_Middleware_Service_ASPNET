namespace _7A.Digital_Signature_Middleware.Abstractions;

public interface ISession
{
    bool close();
    void login();
}
