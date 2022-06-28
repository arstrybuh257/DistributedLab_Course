using DuckCoin.Cryptography.Encryption;
using DuckCoin.Cryptography.Hashing;
using DuckCoin.Wallet.Core.Abstractions;
using DuckCoin.Wallet.DomainModels;
using System.Text.Json;

namespace DuckCoin.Wallet.Core
{
    public class TransactionManager : ITransactionManager
    {
        private readonly IEncryptor _encryptor;
        private readonly IHashFunction _hasFunction;

        public TransactionManager(IEncryptor encryptor, IHashFunction hashFunction)
        {
            _encryptor = encryptor;
            _hasFunction = hashFunction;
        }

        public Transaction CreateTransaction(List<Operation> operations, string privateKey)
        {
            var transaction = new Transaction();

            foreach (var operation in operations)
            {
                operation.SignOperation(_encryptor, privateKey);
                transaction.AddOperation(operation);
            }

            var transactionString = transaction.GetTransactionString();
            var transactionHash = _hasFunction.GetHash(transactionString);
            transaction.SetTransactionId(transactionHash);

            return transaction;
        }

        public TransactionValidationResult ValidateTransaction(Transaction transaction, double currentBalance)
        {
            double totalAmount = 0;

            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            transaction.Operations.ForEach(o => totalAmount += o.Amount);

            if (totalAmount > currentBalance)
            {
                return new TransactionValidationResult()
                {
                    IsValid = false,
                    Error = "You can't spent more money than you have."
                };
            }

            return new TransactionValidationResult()
            {
                IsValid = true,
                Error = null
            };
        }
    }

    public class TransactionValidationResult
    {
        public bool IsValid { get; set; }

        public string? Error { get; set; }
    }
}
