using DuckCoin.Dto;

namespace DuckCoin.Wallet.HttpClients
{
    public interface IFullNodeHttpClient
    {
        Task<IEnumerable<OperationDto>> GetAllAccountOperationsAsync(string accountAddress);
        Task PostTransactionAsync(TransactionDto transactionDto);
        Task PostAccountAsync(string accountAddress);
    }
}
