using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Core
{
    public interface ITransactionManager
    {
        Transaction CreateTransaction(List<Operation> operations, string privateKey);
    }
}
