using DuckCoin.DataAccess.Abstractions;

namespace DuckCoin.FullNode.DomainModels;

public class Account : BaseEntity
{
    public Account(string accountAddress, double balance = 0)
    {
        AccountAddress = accountAddress;
        Balance = balance;
    }

    public string AccountAddress { get; set; }
    
    public double Balance { get; set; }
}