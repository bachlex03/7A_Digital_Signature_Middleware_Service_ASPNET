namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory.Responses;

class LoginResponse : Response
{
    public String accessToken;
    public String refreshToken;
    public int remainingCounter;
    public int tempLockoutDuration;
}