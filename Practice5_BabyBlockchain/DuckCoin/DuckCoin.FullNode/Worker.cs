using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode
{
    public class Worker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {


            while (!stoppingToken.IsCancellationRequested)
            {
                var block = new Block();


            }
        }
    }
}
