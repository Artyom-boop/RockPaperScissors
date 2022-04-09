using System.Security.Cryptography;
using System.Text;

//Class with key generation and HMAC functions
class KeyGenerator
{
    public string? key;
    public string GenerateKey()
    {
        RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(512);
        key = ConvertByteToString(rsaKey.ExportCspBlob(false));
        return key;
    }
    public string GetHMAC(string movement)
    {
        var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(512);
        byte[] input = Encoding.ASCII.GetBytes(key + movement);
        hashAlgorithm.BlockUpdate(input, 0, input.Length);
        byte[] result = new byte[64];
        hashAlgorithm.DoFinal(result, 0);
        return ConvertByteToString(result);
    }
    private string ConvertByteToString(byte[] array)
    {
       return  BitConverter.ToString(array).Replace("-", "").ToLowerInvariant();
    }
}

