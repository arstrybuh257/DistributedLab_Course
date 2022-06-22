using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.DataAccess
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
    }
}
