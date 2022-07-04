using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services
{
    public interface IBlockService
    {
        Task AddBlockAsync(Block block);
        Task<string?> GetLatestBlocksHashAsync();
    }
}
