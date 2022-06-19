using DuckCoin.Cryptography;
using DuckCoin.DataAccess.Interfaces;

namespace DuckCoin.Wallet.DomainModels
{
    public class Account : IIdentifiable
    {
        public Guid Id { get; set; }

        public Account(KeyPair keyPair, string passwordHash)
        {
            PublicKey = keyPair.PublicKey;
            PrivateKey = keyPair.PrivateKey;
            PasswordHash = passwordHash;
            Balance = 0;
        }

        public string PublicKey { get; set; }

        public string PrivateKey { get; set; }

        public int Balance { get; set; }

        public string PasswordHash { get; set; }
    }
}
