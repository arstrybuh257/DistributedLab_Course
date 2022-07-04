using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode
{
    public class Worker : BackgroundService
    {
        private readonly Blockchain _blockchain;

        public Worker(Blockchain blockchain)
        {
            _blockchain = blockchain;
        }

        //This method will be executing endlessly to create new blocks
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _blockchain.InitializeBlockchainAsync();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _blockchain.CreateNewBlockAsync();
                }
                catch
                {
                    continue;
                }               
            }
        }
    }
}
