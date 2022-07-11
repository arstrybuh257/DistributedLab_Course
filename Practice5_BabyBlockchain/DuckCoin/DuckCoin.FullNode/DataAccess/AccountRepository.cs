using System.Linq.Expressions;
using DuckCoin.DataAccess.Abstractions;
using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.DataAccess;

public class AccountRepository : IAccountRepository
{
    private readonly IRepository<Account> _internalRepository;

    public AccountRepository(IRepository<Account> internalRepository)
    {
        _internalRepository = internalRepository;
    }

    public async Task<IEnumerable<Account>> FindAccountsAsync(Expression<Func<Account, bool>> predicate)
    {
        return await _internalRepository.FindAsync(predicate).ConfigureAwait(false);
    }

    public async Task AddAccountAsync(Account account)
    {
        await _internalRepository.AddAsync(account).ConfigureAwait(false);
    }

    public async Task UpdateAccountAsync(Account account)
    {
        await _internalRepository.UpdateAsync(account).ConfigureAwait(false);
    }
    
    public async Task<bool> ExistsAsync(string accountAddress)
    {
        return await _internalRepository.ExistsAsync(x => x.AccountAddress == accountAddress);
    }
}