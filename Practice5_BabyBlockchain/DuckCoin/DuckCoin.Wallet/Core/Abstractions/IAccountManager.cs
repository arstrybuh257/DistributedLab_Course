using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet.Core.Abstractions
{
    public interface IAccountManager
    {
        Account CreateAccount(string password);
    }
}
