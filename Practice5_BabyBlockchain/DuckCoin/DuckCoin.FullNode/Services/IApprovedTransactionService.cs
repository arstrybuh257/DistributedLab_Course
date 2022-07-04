using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services
{
    public interface IApprovedTransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
        Task<bool> IsTransactionExists(string transactionId);
    }
}
