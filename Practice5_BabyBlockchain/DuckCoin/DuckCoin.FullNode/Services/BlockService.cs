using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;
using DuckCoin.FullNode.Services.Abstractions;

namespace DuckCoin.FullNode.Services
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;

        public BlockService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task AddBlockAsync(Block block)
        {
            await _blockRepository.AddBlockAsync(block).ConfigureAwait(false);
        }

        public async Task<string?> GetLatestBlocksHashAsync()
        {
            var blocks = await _blockRepository.FindBlocksAsync(x => true);
            return blocks.MaxBy(x=> x.CreationTimeStamp)?.BlockId;
        }
    }
}
