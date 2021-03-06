using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services.Abstractions
{
    public interface IBlockService
    {
        Task AddBlockAsync(Block block);
        Task<string?> GetLatestBlocksHashAsync();
    }
}
