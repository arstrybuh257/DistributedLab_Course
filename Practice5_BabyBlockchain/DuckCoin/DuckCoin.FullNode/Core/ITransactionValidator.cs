using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Core;

public interface ITransactionValidator
{
    Task<bool> ValidateTransactionAsync(Transaction transaction);
}