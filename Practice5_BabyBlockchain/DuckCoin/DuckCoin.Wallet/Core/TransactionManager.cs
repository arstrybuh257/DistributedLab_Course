using DuckCoin.Cryptography.Encryption;
using DuckCoin.Cryptography.Hashing;
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
                var signedOperation = SignOperation(operation, privateKey);
                transaction.AddOperation(signedOperation);
            }

            var transactionString = JsonSerializer.Serialize(transaction);
            var transactionHash = _hasFunction.GetHash(transactionString);
            transaction.SetTransactionId(transactionHash);

            return transaction;
        }

        private SignedOperation SignOperation(Operation operation, string privateKey)
        {
            var operationString = JsonSerializer.Serialize(operation);
            var signature = _encryptor.Sign(operationString, privateKey);
            return new SignedOperation(operation, signature);
        }
    }
}
