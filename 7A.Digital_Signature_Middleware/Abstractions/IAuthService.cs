namespace _7A.Digital_Signature_Middleware.Abstractions;

public interface IAuthService
{
    string Login(string username, string password);
}
