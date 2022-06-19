using System.Security.Cryptography;

namespace DuckCoin.Cryptography
{
    public class RSAEncryptor : IEncryptor
    {
        public KeyPair GenerateKeys()
        {
            using var rsa = new RSACryptoServiceProvider(512);
            var privateParameters = rsa.ExportParameters(true);
            var publicParameters = rsa.ExportParameters(false);
            var publicKey = Convert.ToBase64String(GetArray(publicParameters));
            var privateKey = Convert.ToBase64String(GetArray(privateParameters));
            return new KeyPair(publicKey, privateKey);
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
