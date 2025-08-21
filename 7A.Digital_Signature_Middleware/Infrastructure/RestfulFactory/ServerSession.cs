using _7A.Digital_Signature_Middleware.Abstractions;
using _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory.Requests;
using _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory.Responses;
using _7A.Digital_Signature_Middleware.Utils;
using Newtonsoft.Json;

namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory;

public class ServerSession : IServerSession
{
    private String bearer;
    private String refreshToken;
    private Property property;
    private String lang;
    private string username;
    private string password;
    private int retryLogin = 0;

    public ServerSession(Property prop, string lang, string username, string password)
    {
        this.property = prop;
        this.lang = lang;
        this.username = username;
        this.password = password;
        this.login();
    }

    public void login()
    {
        Console.WriteLine("____________auth/login____________");
        String authHeader;
        if (refreshToken != null)
        {
            authHeader = refreshToken;
        }
        else
        {
            retryLogin++;
            authHeader = property.getAuthorization(this.username, this.password);
        }
        Console.WriteLine("Login-retry: " + retryLogin);
        LoginRequest loginRequest = new LoginRequest();
        loginRequest.rememberMeEnabled = true;
        loginRequest.relyingParty = property.relyingParty;
        loginRequest.lang = this.lang;

        string jsonReq = JsonConvert.SerializeObject(loginRequest, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        //, DefaultValueHandling = DefaultValueHandling.Ignore });
        string jsonResp = HTTPUtils.sendPost(property.baseUrl + "auth/login", jsonReq, authHeader);
        //Console.WriteLine(jsonResp);

        LoginResponse signCloudResp = JsonConvert.DeserializeObject<LoginResponse>(jsonResp);
        if (signCloudResp.error == 3005 || signCloudResp.error == 3006)
        {
            refreshToken = null;
            if (retryLogin >= 5)
            {
                retryLogin = 0;
                throw new ApiException(signCloudResp.error, signCloudResp.errorDescription);
            }
            login();
        }
        else if (signCloudResp.error != 0)
        {
            throw new ApiException(signCloudResp.error, signCloudResp.errorDescription);
        }
        else
        {
            this.bearer = "Bearer " + signCloudResp.accessToken;
            if (signCloudResp.refreshToken != null)
            {
                this.refreshToken = "Bearer " + signCloudResp.refreshToken;
                Console.WriteLine("Response code: " + signCloudResp.error);
                Console.WriteLine("Response Desscription: " + signCloudResp.errorDescription);
                Console.WriteLine("Response ID: " + signCloudResp.responseID);
                Console.WriteLine("AccessToken: " + signCloudResp.accessToken);
            }
        }
    }

    public bool close()
    {
        throw new NotImplementedException();
    }
}
