using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services.Abstractions;

public interface IAccountService
{
    public Task<Account?> GetAccountByAddressAsync(string? accountAddress);

    public Task AddAccountAsync(Account account);
    
    public Task UpdateAccountAsync(Account account);

    public Task<bool> ExistsAsync(string? accountAddress);
}