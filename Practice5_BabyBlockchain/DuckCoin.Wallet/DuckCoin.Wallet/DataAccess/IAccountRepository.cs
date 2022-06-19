using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.DataAccess
{
    public interface IAccountRepository
    {
        Task AddAccount(Account account);
    }
}
