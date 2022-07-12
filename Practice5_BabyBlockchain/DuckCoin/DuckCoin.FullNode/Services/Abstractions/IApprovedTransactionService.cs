using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services.Abstractions
{
    public interface IApprovedTransactionService
    {
        Task<IEnumerable<Operation>> GetOperationsByAccountIdAsync(string accountId);
        Task AddTransactionAsync(Transaction transaction);
        Task<bool> IsTransactionExists(string transactionId);
    }
}
