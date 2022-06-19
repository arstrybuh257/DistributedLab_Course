using System.Security.Cryptography;
using System.Text;

namespace DuckCoin.Cryptography.Hashing
{
    public class SHA1Hash : IHashFunction
    {
        public string GetHash(string data)
        {
            var sha = SHA1.HashData(Encoding.UTF8.GetBytes(data));
            return string.Concat(sha.Select(x => $"{x:x2}"));
        }
    }
}
