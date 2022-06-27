using DuckCoin.DataAccess.Abstractions;

namespace DuckCoin.Wallet.DomainModels
{
    public class Transaction : BaseEntity
    {
        public string? TransactionId { get; private set; }

        public List<Operation> Operations { get; private set; }

        public long Nonce { get; set; }

        //This fields shows if this transaction was processed and added to blockchain or it's just local one yet.
        public bool IsBlockhainTransaction { get; set; }

        public Transaction()
        {
            Operations = new List<Operation>();
            IsBlockhainTransaction = false;
            Nonce = DateTime.Now.Ticks;
        }

        public void AddOperation(Operation operation)
        {
            Operations.Add(operation);
        }

        public void SetTransactionId(string transactionHash)
        {
            TransactionId = transactionHash;
        }

        public double GetTotalAmount()
        {
            double totalAmount = 0;
            Operations.ForEach(o => totalAmount += o.Amount);
            return totalAmount;
        }
    }
}
