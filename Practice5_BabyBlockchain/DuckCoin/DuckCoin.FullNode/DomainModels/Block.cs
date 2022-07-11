using DuckCoin.DataAccess.Abstractions;
using System.Text;

namespace DuckCoin.FullNode.DomainModels
{
    public class Block : BaseEntity
    {
        public string? BlockId { get; private set; }

        public string? PrevHash { get; set; }

        public List<Transaction> Transactions { get; set; }

        //This field will be used for Proof of Work stuff 
        public long Nonce { get; set; }

        public string? ProofOfWork { get; set; }

        public long CreationTimeStamp { get; set; }

        public Block(string? prevHash)
        {
            PrevHash = prevHash;
            Transactions = new List<Transaction>();
            Nonce = 0;
            ProofOfWork = null;
            CreationTimeStamp = DateTime.UtcNow.Ticks;
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void SetBlockId(string blockId)
        {
            BlockId = blockId;
        }

        public string GetBlockString()
        {
            var sb = new StringBuilder();

            foreach (var transaction in Transactions)
            {
                sb.Append(transaction.GetTransactionString());
            }

            sb.Append(PrevHash);
            sb.Append(CreationTimeStamp);
            sb.Append(Nonce);
            
            return sb.ToString();
        }
    }
}
