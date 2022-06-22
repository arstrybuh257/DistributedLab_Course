using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Services
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
    }
}
