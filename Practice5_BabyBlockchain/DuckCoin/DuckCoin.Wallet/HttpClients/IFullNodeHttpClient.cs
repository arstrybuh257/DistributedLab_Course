using DuckCoin.Dto;

namespace DuckCoin.Wallet.HttpClients
{
    public interface IFullNodeHttpClient
    {
        Task PostTransactionAsync(TransactionDto transactionDto);
        Task PostAccountAsync(string accountAddress);
    }
}
