using DuckCoin.Cryptography.Hashing;
using DuckCoin.Wallet.DataAccess;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Services
{
    public class AccountServices : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IHashFunction _hashFunction;

        public AccountServices(IAccountRepository accountRepository, IHashFunction hashFunction)
        {
            _accountRepository = accountRepository;
            _hashFunction = hashFunction;
        }

        public async Task AddAccountAsync(Account account)
        {
            await _accountRepository.AddAccountAsync(account).ConfigureAwait(false);
        }

        public async Task<Account> GetAccountAsync(string accountId)
        {
            return await _accountRepository.GetAccountByPredicateAsync(x => accountId.Equals(x.AccountAddress)).ConfigureAwait(false);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            await _accountRepository.UpdateAccountAsync(account).ConfigureAwait(false);
        }

        public async Task<bool> ValidatePasswordAsync(string addressHash, string password)
        {
            var account = await GetAccountAsync(addressHash).ConfigureAwait(false);

            if (account == null)
            {
                return false;
            }

            if (account.PasswordHash.Equals(_hashFunction.GetHash(password)))
            {
                return true;
            }

            return false;
        }
    }
}
