using DuckCoin.DataAccess.Abstractions;
using DuckCoin.Wallet.DomainModels;
using System.Linq.Expressions;

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

        public async Task<Account> GetAccountByPredicateAsync(Expression<Func<Account, bool>> predicate)
        {
            return await _internalRepository.GetAsync(predicate).ConfigureAwait(false);
        }
    }
}
