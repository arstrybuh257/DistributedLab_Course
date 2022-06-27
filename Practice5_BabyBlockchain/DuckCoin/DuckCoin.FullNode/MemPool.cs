using DuckCoin.FullNode.DomainModels;
using System.Collections.Concurrent;

namespace DuckCoin.FullNode
{
    public static class MemPool
    {
        private static ConcurrentQueue<Transaction> _transactionQueue = new ConcurrentQueue<Transaction>();

        public static void AddTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }

            _transactionQueue.Enqueue(transaction);
        }

        public static Transaction? GetTransaction()
        {
            _transactionQueue.TryDequeue(out var transaction);
            return transaction;                    
        }
    }
}
