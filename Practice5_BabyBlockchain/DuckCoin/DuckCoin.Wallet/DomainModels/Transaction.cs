using DuckCoin.DataAccess.Abstractions;

namespace DuckCoin.Wallet.DomainModels
{
    public class Transaction : BaseEntity
    {
        public string? TransactionId { get; private set; }

        public List<SignedOperation> SignedOperations { get; private set; }

        public long Nonce { get; set; }

        //This fields shows if this transaction was processed and added to blockchain or it's just local one yet.
        public bool IsBlockhainTransaction { get; set; }

        public Transaction()
        {
            SignedOperations = new List<SignedOperation>();
            IsBlockhainTransaction = false;
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

        public double GetTotalAmount()
        {
            double totalAmount = 0;
            SignedOperations.ForEach(o => totalAmount += o.Data.Amount);
            return totalAmount;
        }
    }
}
