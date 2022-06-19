using DuckCoin.Wallet.DomainModels;

namespace DuckCoin.Wallet
{
    public interface IAccountManager
    {
        Account CreateAccount(string password);
    }
}
