using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Services
{
    public interface IAccountService
    {
        Task<Account> GetAccountAsync(string accountId);
        Task AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task<bool> ValidatePasswordAsync(string addressHash, string password);
    }
}
