using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services.Abstractions;

namespace DuckCoin.FullNode.Services;

public class ApprovedTransactionService : IApprovedTransactionService
{
    private readonly IApprovedTransactionRepository _approvedTransactionRepository;

    public ApprovedTransactionService(IApprovedTransactionRepository approvedTransactionRepository)
    {
        _approvedTransactionRepository = approvedTransactionRepository;
    }

    public async Task<IEnumerable<Operation>> GetOperationsByAccountIdAsync(string accountId)
    {
        var transactions = 
            await _approvedTransactionRepository.FindTransactionsAsync(x => x.Operations.Any(
                op => op.ReceiverAddress == accountId || op.SenderAddress == accountId));

        var operations = new List<Operation>();

        foreach (var transaction in transactions)
        {
            operations.AddRange(transaction.Operations
                .Where(op => op.ReceiverAddress == accountId || op.SenderAddress == accountId));
        }

        return operations;
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _approvedTransactionRepository.AddTransactionAsync(transaction).ConfigureAwait(false);
    }

    public async Task<bool> IsTransactionExists(string transactionId)
    {
        var transaction = await _approvedTransactionRepository
            .GetTransactionByPredicateAsync(x => x.TransactionId == transactionId).ConfigureAwait(false);

        return transaction != null;
    }
}