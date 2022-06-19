using DuckCoin.Cryptography.Encryption;
using DuckCoin.DataAccess.Interfaces;

namespace DuckCoin.Wallet.DomainModels
{
    public class Account : IIdentifiable
    {
        public Guid Id { get; set; }

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

        public int Balance { get; set; }

        public string PasswordHash { get; set; }

        public string PublicKeyHash { get; set; }
    }
}
