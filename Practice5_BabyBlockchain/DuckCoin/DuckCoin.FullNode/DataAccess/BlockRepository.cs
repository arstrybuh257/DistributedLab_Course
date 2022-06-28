using DuckCoin.DataAccess.Abstractions;
using DuckCoin.FullNode.DataAccess.Abstractions;
using DuckCoin.FullNode.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.FullNode.DataAccess
{
    public class BlockRepository : IBlockRepository
    { 
        private readonly IRepository<Block> _internalRepository;

        public BlockRepository(IRepository<Block> internalRepository)
        {
            _internalRepository = internalRepository;
        }

        public async Task AddBlockAsync(Block block)
        {
            await _internalRepository.AddAsync(block).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Block>> FindBlocksAsync(Expression<Func<Block, bool>> predicate)
        {
            return await _internalRepository.FindAsync(predicate).ConfigureAwait(false);
        }

        public async Task<Block> GetBlockByPredicateAsync(Expression<Func<Block, bool>> predicate)
        {
            return await _internalRepository.GetAsync(predicate).ConfigureAwait(false);
        }
    }
}
