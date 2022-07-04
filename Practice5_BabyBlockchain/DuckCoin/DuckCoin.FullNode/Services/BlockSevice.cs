using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.Services
{
    public class BlockSevice : IBlockService
    {
        private readonly IBlockRepository _blockRepository;

        public BlockSevice(IBlockRepository blockRepository)
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

            if( blocks == null || !blocks.Any())
            {
                return null;
            }

            return blocks.OrderByDescending(x=> x.CreationTimeStamp).First().BlockId;
        }
    }
}
