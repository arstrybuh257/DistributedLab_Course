using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services.Abstractions;

namespace DuckCoin.FullNode.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Account?> GetAccountByAddressAsync(string accountAddress)
    {
        return (await _accountRepository.FindAccountsAsync(x => x.AccountAddress == accountAddress)
            .ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task AddAccountAsync(Account account)
    {
        await _accountRepository.AddAccountAsync(account).ConfigureAwait(false);
    }

    public async Task UpdateAccountAsync(Account account)
    {
        await _accountRepository.UpdateAccountAsync(account).ConfigureAwait(false);
    }

    public async Task<bool> ExistsAsync(string accountAddress)
    {
        return await _accountRepository.ExistsAsync(accountAddress).ConfigureAwait(false);
    }
}