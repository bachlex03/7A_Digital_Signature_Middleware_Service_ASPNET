namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory;

class ApiException : Exception
{
    public int error { get; }
    public ApiException(int code, String msg) : base(msg)
    {
        this.error = code;
    }

    public ApiException(String msg) : base(msg)
    {
        this.error = -1;
    }
}