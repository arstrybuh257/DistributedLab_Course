using DuckCoin.Cryptography.Hashing;
using DuckCoin.FullNode.Services.Abstractions;

namespace DuckCoin.FullNode.DomainModels
{
    public class Blockchain
    {
        private const string ProofOfWorkStartSubstring = "000"; 
        
        private bool _isInitialized;
        private readonly IBlockService _blockService;
        private readonly IAccountService _accountService;
        private readonly IHashFunction _hashFunction;
        private readonly IApprovedTransactionService _approvedTransactionService;

        public Blockchain(IBlockService blockService, IApprovedTransactionService approvedTransactionService, 
            IHashFunction hashFunction)
        {
            _isInitialized = false;
            _blockService = blockService;
            _approvedTransactionService = approvedTransactionService;
            _hashFunction = hashFunction;
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
                
                block.AddTransaction(transaction);
                await UpdateBalancesAsync(transaction);
                
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
        
        private void PerformProofOfWork(Block block)
        {
            string hash = _hashFunction.GetHash(block.GetBlockString());
            
            while(!hash.StartsWith(ProofOfWorkStartSubstring))
            {
                block.Nonce++;
                hash = _hashFunction.GetHash(block.GetBlockString());
            }

            block.ProofOfWork = hash;
        }

        private async Task UpdateBalancesAsync(Transaction acceptedTransaction)
        {
            foreach (var operation in acceptedTransaction.Operations)
            {
                var senderAccount = await _accountService.GetAccountByAddressAsync(operation.SenderAddress);

                if (senderAccount == null)
                {
                    throw new InvalidOperationException(
                        $"There is no sender account with address {operation.SenderAddress} found");
                }

                senderAccount.Balance -= operation.Amount;
                await _accountService.UpdateAccountAsync(senderAccount);
                
                var receiverAccount = await _accountService.GetAccountByAddressAsync(operation.ReceiverAddress);

                if (receiverAccount == null)
                {
                    receiverAccount = new Account(operation.ReceiverAddress, operation.Amount);
                    await _accountService.AddAccountAsync(receiverAccount);
                }
                else
                {
                    receiverAccount.Balance += operation.Amount;
                    await _accountService.UpdateAccountAsync(receiverAccount);
                }
            }
        }
    }
}
