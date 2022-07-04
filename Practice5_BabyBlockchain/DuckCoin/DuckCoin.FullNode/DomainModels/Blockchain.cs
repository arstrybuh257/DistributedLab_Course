using DuckCoin.FullNode.Services;

namespace DuckCoin.FullNode.DomainModels
{
    public class Blockchain
    {
        private bool _isInitialized;
        private readonly IBlockService _blockService;
        private readonly IApprovedTransactionService _approvedTransactionService;

        public Blockchain(IBlockService blockService, IApprovedTransactionService approvedTransactionService)
        {
            _isInitialized = false;
            _blockService = blockService;
            _approvedTransactionService = approvedTransactionService;
        }

        //We create a new block only if there is no blocks in database
        public async Task InitializeBlockchainAsync()
        {
            if (_isInitialized) { return; }

            var prevBlockHash = await _blockService.GetLatestBlocksHashAsync().ConfigureAwait(false);

            if (prevBlockHash != null) { return; }

            var genesisBlock = new Block(null);

            await _blockService.AddBlockAsync(genesisBlock).ConfigureAwait(false);

            _isInitialized = true;
        }

        public async Task CreateNewBlockAsync()
        {
            var prevBlockHash = await _blockService.GetLatestBlocksHashAsync().ConfigureAwait(false);

            if(prevBlockHash == null) 
            {
                throw new InvalidOperationException("Blockchain is not initialized yet. No blocks found in db");
            }

            var block = new Block(prevBlockHash);

            var includedTransactionsCount = 0;

            while (!MemPool.IsEmpty || includedTransactionsCount < 5)
            {
                var transaction = MemPool.GetTransaction();

                var isTransactionExists = await _approvedTransactionService.IsTransactionExists(transaction.TransactionId).ConfigureAwait(false);

                //If transaction is already approved and exist in database we skip it and try to get next one
                if (isTransactionExists)
                {
                    continue;
                }

                //If transaction is invalid for some reason we skip it and try to get next
                if (!IsTransactionValid(transaction))
                {
                    continue;
                }

                block.AddTransaction(transaction);

                PerformProofOfWork(block);


                await _approvedTransactionService.AddTransactionAsync(transaction).ConfigureAwait(false);
                includedTransactionsCount++;
            }

            //If there is an exception while block saving we should return all transactions from this block to mempool
            try
            {
                await _blockService.AddBlockAsync(block).ConfigureAwait(false);
            }
            finally
            {
                //TODO Implement rollback logic
            }
        }

        //TODO inplement this method
        private bool IsTransactionValid(Transaction transaction)
        {
            return true;
        }

        //TODO implement this method
        private void PerformProofOfWork(Block block)
        {

        }
    }
}
