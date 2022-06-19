using DuckCoin.Cryptography;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet
{
    public class AccountManager : IAccountManager
    {
        private readonly IEncryptor _encryptor;

        public AccountManager(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public Account CreateAccount(string password)
        {
            var keyPair = _encryptor.GenerateKeys();
            return new Account(keyPair, password);
        }
    }
}
