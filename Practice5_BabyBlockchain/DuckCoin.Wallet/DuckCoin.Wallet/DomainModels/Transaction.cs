using DuckCoin.DataAccess.Interfaces;

namespace DuckCoin.Wallet.DomainModels
{
    public class Transaction : IIdentifiable
    {
        public Guid Id { get;  }

        public string? TransactionId { get; private set; }

        public List<SignedOperation> SignedOperations { get; }

        public long Nonce { get; set; }

        public Transaction()
        {
            SignedOperations = new List<SignedOperation>();
            Nonce = DateTime.Now.Ticks;
        }

        public void AddOperation(SignedOperation operation)
        {
            SignedOperations.Add(operation);
        }

        public void SetTransactionId(string transactionHash)
        {
            TransactionId = transactionHash;
        }
    }
}
