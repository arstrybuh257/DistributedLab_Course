using DuckCoin.DataAccess.Abstractions;
using System.Text;

namespace DuckCoin.FullNode.DomainModels
{
    public class Block : BaseEntity
    {
        public string? BlockId { get; private set; }

        public string PrevHash { get; set; }

        public List<Transaction> Transactions { get; set; }

        //This field will be used for Proof of Work stuff 
        public long Nonce { get; set; }

        public string? ProofOfWork { get; set; }

        public Block(string prevHash)
        {
            PrevHash = prevHash;
            Transactions = new List<Transaction>();
            Nonce = 0;
            ProofOfWork = null;
        }

        public bool TryAddTransaction(Transaction transaction)
        {
            if(Transactions.Count >= 5)
            {
                return false;
            }

            if (Transactions.Any(t=> t.TransactionId == transaction.TransactionId))
            {
                return false;
            }

            Transactions.Add(transaction);
            return true;
        }

        public void SetBlockId(string blockId)
        {
            BlockId = blockId;
        }

        public void GetBlockString()
        {
            var sb = new StringBuilder();

            foreach (var transaction in Transactions)
            {
                sb.Append(transaction.GetTransactionString());
            }

            sb.Append(PrevHash);
        }
    }
}
