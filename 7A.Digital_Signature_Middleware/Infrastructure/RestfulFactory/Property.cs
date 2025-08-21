using _7A.Digital_Signature_Middleware.Utils;

namespace _7A.Digital_Signature_Middleware.Infrastructure.RestfulFactory;

public class Property
{
    public string profile = "rssp-119.432-v2.0";
    public string baseUrl { get; }
    public string relyingParty { get; }
    public string relyingPartyUser { get; }
    public string relyingPartyPassword { get; }
    public string relyingPartySignature { get; }
    public string relyingPartyKeyStore { get; }
    public string relyingPartyKeyStorePassword { get; }

    public Property(string baseUrl,
                    string relyingParty,
                    string relyingPartyUser,
                    string relyingPartyPassword,
                    string relyingPartySignature,
                    string relyingPartyKeyStore,
                    string relyingPartyKeyStorePassword)
    {
        this.baseUrl = baseUrl;
        this.relyingParty = relyingParty;
        this.relyingPartyUser = relyingPartyUser;
        this.relyingPartyPassword = relyingPartyPassword;
        this.relyingPartySignature = relyingPartySignature;
        this.relyingPartyKeyStore = relyingPartyKeyStore;
        this.relyingPartyKeyStorePassword = relyingPartyKeyStorePassword;
    }

    public string getAuthorization(string username, string password)
    {
        string timestamp = Utilities.CurrentTimeMillis().ToString();
        string data2sign = relyingPartyUser + relyingPartyPassword + relyingPartySignature + timestamp;
        string pkcs1Signature = Utilities.GetPKCS1Signature(data2sign, relyingPartyKeyStore, relyingPartyKeyStorePassword);
        //sreturn "SSL2 " + Utils.Base64Encode(Encoding.ASCII.GetBytes(DemoFunction.relyingPartyUser + ":"+ DemoFunction.relyingPartyPassword + ":"+ DemoFunction.relyingPartySignature + ":"+ timestamp + ":"+ pkcs1Signature));
        //return "SSL2 " + Utils.Base64Encode((relyingPartyUser + ":" + relyingPartyPassword + ":" + relyingPartySignature + ":" + timestamp + ":" + pkcs1Signature));

        string SSL2 = relyingPartyUser + ":" + relyingPartyPassword + ":" + relyingPartySignature + ":" + timestamp + ":" + pkcs1Signature;
        string Basic = "USERNAME:" + username + ":" + password;
        string BasicEncode = Utilities.Base64Encode(Basic);

        //string test = Convert.ToBase64String(byteSSL2);

        return "SSL2 " + Utilities.Base64Encode(SSL2)
            + ", Basic "
            + BasicEncode;
    }
}
