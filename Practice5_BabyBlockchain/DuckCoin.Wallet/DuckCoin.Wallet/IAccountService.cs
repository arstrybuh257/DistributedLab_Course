using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet
{
    public interface IAccountService
    {
        Task AddAccountAsync(Account account);
        Task<bool> ValidatePasswordAsync(string addressHash, string password);
    }
}
