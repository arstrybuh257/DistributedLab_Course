using DuckCoin.Cryptography.Encryption;
using DuckCoin.Wallet.DomainModels;
using System.Text.Json;

namespace DuckCoin.Wallet.Core
{
    public class TransactionManager : ITransactionManager
    {
        private readonly IEncryptor _encryptor;

        public TransactionManager(IEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public Transaction CreateTransaction(List<Operation> operations, string privateKey)
        {
            var transaction = new Transaction();

            foreach (var operation in operations)
            {
                var signedOperation = SignOperation(operation, privateKey);
                transaction.AddOperation(signedOperation);
            }

            transaction.
        }

        private SignedOperation SignOperation(Operation operation, string privateKey)
        {
            var operationString = JsonSerializer.Serialize(operation);
            var signature = _encryptor.Sign(operationString, privateKey);
            return new SignedOperation(operation, signature);
        }
    }
}
