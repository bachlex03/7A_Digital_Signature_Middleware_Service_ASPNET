using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

namespace _7A.Digital_Signature_Middleware.Utils;

public class MakeSignature
{
    private String data;
    private String key;
    private String passKey;

    public MakeSignature(String data, String PriKeyPath, String PriKeyPass)
    {
        this.data = data;
        this.key = PriKeyPath;
        this.passKey = PriKeyPass;
    }

    public String getSignature()
    {
        using (RSA rsa = GetKey())
        {
            return Sign(this.data, rsa);
        }
    }

    public static string Sign(string content, RSA rsa)
    {
        byte[] data = Encoding.UTF8.GetBytes(content);
        byte[] signature = rsa.SignData(data, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
        return Convert.ToBase64String(signature);
    }

    private RSA GetKey()
    {
        try
        {
            X509Certificate2 cert2 = new X509Certificate2(
                this.key,
                this.passKey,
                X509KeyStorageFlags.MachineKeySet |
                X509KeyStorageFlags.PersistKeySet |
                X509KeyStorageFlags.Exportable);

            // Get the RSA private key
            RSA? rsa = cert2.GetRSAPrivateKey();
            if (rsa == null)
            {
                throw new CryptographicException("Certificate does not contain an RSA private key.");
            }

            // Optional: Log the public key for debugging
            byte[] publicKey = cert2.PublicKey.EncodedKeyValue.RawData;
            // Console.WriteLine(Convert.ToBase64String(publicKey));

            return rsa;
        }
        catch (Exception ex)
        {
            throw new CryptographicException("Failed to load the private key from the certificate.", ex);
        }
    }

}
