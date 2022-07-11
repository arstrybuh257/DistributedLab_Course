using System.Linq.Expressions;
using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.DataAccess.Abstractions;

public interface IAccountRepository
{
    public Task<IEnumerable<Account>> FindAccountsAsync(Expression<Func<Account, bool>> predicate);

    public Task AddAccountAsync(Account account);
    
    public Task UpdateAccountAsync(Account account);

    Task<bool> ExistsAsync(string accountAddress);
}