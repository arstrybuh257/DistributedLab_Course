using DuckCoin.FullNode.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.FullNode.DataAccess.Abstractions
{
    public interface IApprovedTransactionRepository
    {
        Task<IEnumerable<Transaction>> FindTransactionsAsync(Expression<Func<Transaction, bool>> predicate);
        Task AddTransactionAsync(Transaction transaction);
        Task<Transaction> GetTransactionByPredicateAsync(Expression<Func<Transaction, bool>> predicate);
    }
}
