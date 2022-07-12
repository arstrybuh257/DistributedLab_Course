using DuckCoin.Cryptography.Encryption;
using DuckCoin.Cryptography.Hashing;
using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services.Abstractions;

namespace DuckCoin.FullNode.Core;

public class TransactionManager : ITransactionManager
{
    private readonly IAccountService _accountService;
    private readonly IEncryptor _encryptor;
    private readonly IHashFunction _hashFunction;

    public TransactionManager(IAccountService accountService, IEncryptor encryptor)
    {
        _accountService = accountService;
        _encryptor = encryptor;
    }

    // public Transaction CreateNewEmissionTransaction(string accountId, double amountOfCoins)
    // {
    //     // var transaction = new Transaction();
    //     // var operation = new Operation(null, accountId, amountOfCoins, null);
    //     // operation.
    //     // transaction.AddOperation(operation);
    //     
    // }

    public async Task<bool> ValidateTransactionAsync(Transaction transaction)
    {
        var spentMoneyBySenders = new Dictionary<string?, double>();
        
        foreach (var operation in transaction.Operations)
        {
            var isSignatureValid = operation.VerifySignature(_encryptor, operation.SenderPublicKey);
            
            //If at least one operation is invalid we stop further checking
            if (!isSignatureValid)
            {
                return false;
            }
            
            if (spentMoneyBySenders.ContainsKey(operation.SenderAddress))
            {
                spentMoneyBySenders[operation.SenderAddress] += operation.Amount;
            }
            else
            {
                spentMoneyBySenders[operation.SenderAddress] = operation.Amount;
            }
        }

        //If a transaction spend more than it can for any of the accounts we stop further checking
        foreach (var keyValuePair in spentMoneyBySenders)
        {
            var account = await _accountService.GetAccountByAddressAsync(keyValuePair.Key);

            if (account == null || account.Balance < keyValuePair.Value)
            {
                return false;
            }
        }

        return true;
    }
}