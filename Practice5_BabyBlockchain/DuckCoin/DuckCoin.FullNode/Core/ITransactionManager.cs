using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Core;

public interface ITransactionManager
{
    //Transaction CreateNewTransaction();
    Task<bool> ValidateTransactionAsync(Transaction transaction);
}