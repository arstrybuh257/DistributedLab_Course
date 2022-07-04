using DuckCoin.DataAccess.Abstractions;
using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.FullNode.DataAccess
{
    public class ApprovedTransactionRepository : IApprovedTransactionRepository
    {
        private readonly IRepository<Transaction> _internalRepository;

        public ApprovedTransactionRepository(IRepository<Transaction> internalRepository)
        {
            _internalRepository = internalRepository;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _internalRepository.AddAsync(transaction).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Transaction>> FindTransactionsAsync(Expression<Func<Transaction, bool>> predicate)
        {
            return await _internalRepository.FindAsync(predicate).ConfigureAwait(false);
        }

        public async Task<Transaction> GetTransactionByPredicateAsync(Expression<Func<Transaction, bool>> predicate)
        {
            return await _internalRepository.GetAsync(predicate).ConfigureAwait(false);
        }
    }
}
