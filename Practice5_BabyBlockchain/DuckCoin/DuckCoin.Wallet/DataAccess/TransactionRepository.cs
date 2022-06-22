using DuckCoin.DataAccess.Abstractions;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IRepository<Transaction> _internalRepository;

        public TransactionRepository(IRepository<Transaction> internalRepository)
        {
            _internalRepository = internalRepository;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _internalRepository.AddAsync(transaction).ConfigureAwait(false);
        }
    }
}
