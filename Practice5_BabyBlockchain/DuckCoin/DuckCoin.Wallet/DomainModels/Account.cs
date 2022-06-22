using DuckCoin.Cryptography.Encryption;
using DuckCoin.DataAccess.Abstractions;

namespace DuckCoin.Wallet.DomainModels
{
    public class Account : BaseEntity
    {
        public Account(KeyPair keyPair, string passwordHash, string publicKeyHash)
        {
            PublicKey = keyPair.PublicKey;
            PrivateKey = keyPair.PrivateKey;
            PublicKeyHash = publicKeyHash;
            PasswordHash = passwordHash;
            Balance = 0;
        }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public double Balance { get; set; }

        public string PasswordHash { get; set; }

        public string PublicKeyHash { get; set; }
    }
}
