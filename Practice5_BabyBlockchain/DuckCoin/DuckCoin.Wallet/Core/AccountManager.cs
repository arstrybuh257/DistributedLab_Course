using DuckCoin.Cryptography.Encryption;
using DuckCoin.Cryptography.Hashing;
using DuckCoin.Wallet.Core.Abstractions;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet
{
    public class AccountManager : IAccountManager
    {
        private readonly IEncryptor _encryptor;
        private readonly IHashFunction _hashFunction;

        public AccountManager(IEncryptor encryptor, IHashFunction hashFunction)
        {
            _encryptor = encryptor;
            _hashFunction = hashFunction;
        }

        public Account CreateAccount(string password)
        {
            var keyPair = _encryptor.GenerateKeys();
            var passwordHash = _hashFunction.GetHash(password);
            var publicKeyHash = _hashFunction.GetHash(keyPair.PublicKey);
            return new Account(keyPair, passwordHash, publicKeyHash);
        }
    }
}
