namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory.Requests;

public class Request
{
    public String profile { get; set; } = "";
    public String lang { get; set; } = "";
    public String requestID { get; set; } = "";
    public String rpRequestID { get; set; } = "";

    public Request()
    {
        this.profile = "rssp-119.432-v2.0";
        this.lang = "VN";
    }
}