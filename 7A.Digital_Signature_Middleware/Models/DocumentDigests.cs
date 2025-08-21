using _7A.Digital_Signature_Middleware.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _7A.Digital_Signature_Middleware.Models;

class DocumentDigests
{
    public List<byte[]> hashes { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public Nullable<HashAlgorithmOID> hashAlgorithmOID { get; set; }
}