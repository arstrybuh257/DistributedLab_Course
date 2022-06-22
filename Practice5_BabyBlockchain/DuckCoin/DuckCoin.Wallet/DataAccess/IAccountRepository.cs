using DuckCoin.Wallet.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.Wallet.DataAccess
{
    public interface IAccountRepository
    {
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task<Account> GetAccountByPredicateAsync(Expression<Func<Account, bool>> predicate);
    }
}
