using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Core.Abstractions
{
    public interface ITransactionManager
    {
        TransactionValidationResult ValidateTransaction(Transaction transaction, double currentBalance);
        Transaction CreateTransaction(List<Operation> operations, string privateKey);
    }
}
