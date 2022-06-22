using DuckCoin.Wallet.DataAccess;
using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _transactionRepository.AddTransactionAsync(transaction).ConfigureAwait(false);
        }
    }
}
