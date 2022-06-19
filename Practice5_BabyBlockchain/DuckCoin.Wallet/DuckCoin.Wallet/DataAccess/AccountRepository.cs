using DuckCoin.DataAccess.Interfaces;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.DataAccess
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IRepository<Account> _internalRepository;

        public AccountRepository(IRepository<Account> internalRepository)
        {
            _internalRepository = internalRepository;
        }

        public async Task AddAccount(Account account)
        {
            await _internalRepository.AddAsync(account).ConfigureAwait(false);
        }
    }
}
