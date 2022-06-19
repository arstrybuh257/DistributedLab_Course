using DuckCoin.Wallet.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.Wallet.DataAccess
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
        Task<Account> GetAccountByPredicateAsync(Expression<Func<Account, bool>> predicate);
    }
}
