using System.Security.Cryptography;
using System.Text;

namespace DuckCoin.Cryptography.Encryption
{
    public class RSAEncryptor : IEncryptor
    {
        public KeyPair GenerateKeys()
        {
            using var rsa = new RSACryptoServiceProvider();
            var privateParameters = rsa.ExportParameters(true);
            var publicParameters = rsa.ExportParameters(false);
            var publicKey = Convert.ToBase64String(GetArray(publicParameters));
            var privateKey = Convert.ToBase64String(GetArray(privateParameters));
            return new KeyPair(publicKey, privateKey);
        }

        public string Sign(string data, string privateKey)
        {
            using var provider = GetCryptoProvider(privateKey);
            var bytes = Encoding.UTF8.GetBytes(data);
            var signedHash = provider.SignData(bytes, SHA256.Create());
            return Convert.ToBase64String(signedHash);
        }

        public bool VerifySign(string publicKey, string data, string sign)
        {
            using var provider = GetVerificationProvider(publicKey);
            var signBytes = Convert.FromBase64String(sign);
            var dataBytes = Encoding.UTF8.GetBytes(data);
            return provider.VerifyData(dataBytes, SHA256.Create(), signBytes);
        }

        private RSACryptoServiceProvider GetCryptoProvider(string privateKey)
        {
            var privateParameter = GetPrivateKey(Convert.FromBase64String(privateKey));
            var provider = new RSACryptoServiceProvider();
            provider.ImportParameters(privateParameter);

            return provider;
        }

        private RSACryptoServiceProvider GetVerificationProvider(string publicKey)
        {
            var parameter = GetPublicKey(Convert.FromBase64String(publicKey));
            var provider = new RSACryptoServiceProvider();
            provider.ImportParameters(parameter);
            return provider;
        }

        private byte[] FillArray(int length, byte[] byteRepresentation, ref int pos)
        {
            var result = new byte[length];
            Array.Copy(byteRepresentation, pos, result, 0, length);
            pos += length;
            return result;
        }

        private RSAParameters GetPublicKey(byte[] byteRepresentation)
        {
            int pos = 0;
            var result = new RSAParameters();
            result.Exponent = FillArray(3, byteRepresentation, ref pos);
            result.Modulus = FillArray(128, byteRepresentation, ref pos);
            return result;
        }

        private RSAParameters GetPrivateKey(byte[] byteRepresentation)
        {
            int pos = 0;
            var result = new RSAParameters();
            result.D = FillArray(128, byteRepresentation, ref pos);
            result.DP = FillArray(64, byteRepresentation, ref pos);
            result.DQ = FillArray(64, byteRepresentation, ref pos);
            result.Exponent = FillArray(3, byteRepresentation, ref pos);
            result.InverseQ = FillArray(64, byteRepresentation, ref pos);
            result.Modulus = FillArray(128, byteRepresentation, ref pos);
            result.P = FillArray(64, byteRepresentation, ref pos);
            result.Q = FillArray(64, byteRepresentation, ref pos);
            return result;
        }

        private byte[] GetArray(RSAParameters p)
        {
            var length =
                  GetLength(p.D)
                + GetLength(p.DP)
                + GetLength(p.DQ)
                + GetLength(p.Exponent)
                + GetLength(p.InverseQ)
                + GetLength(p.Modulus)
                + GetLength(p.P)
                + GetLength(p.Q);

            length = (length / 4 + 1) * 4;

            byte[] data = new byte[length];
            var pos = 0;
            pos = CopyTo(data, p.D, pos);
            pos = CopyTo(data, p.DP, pos);
            pos = CopyTo(data, p.DQ, pos);
            pos = CopyTo(data, p.Exponent, pos);
            pos = CopyTo(data, p.InverseQ, pos);
            pos = CopyTo(data, p.Modulus, pos);
            pos = CopyTo(data, p.P, pos);
            CopyTo(data, p.Q, pos);

            return data;
        }

        private int GetLength(byte[]? d)
        {
            return d?.Length ?? 0;
        }

        private int CopyTo(byte[] buffer, byte[]? dataToCopy, int pos)
        {
            if (dataToCopy != null)
            {
                dataToCopy.CopyTo(buffer, pos);
                return pos + dataToCopy.Length;
            }
            return pos;
        }
    }
}
