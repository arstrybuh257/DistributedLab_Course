using DuckCoin.FullNode.DomainModels;
using System.Linq.Expressions;

namespace DuckCoin.FullNode.DataAccess.Abstractions
{
    public interface IBlockRepository
    {
        Task<IEnumerable<Block>> FindBlocksAsync(Expression<Func<Block, bool>> predicate);
        Task AddBlockAsync(Block block);
        Task<Block> GetBlockByPredicateAsync(Expression<Func<Block, bool>> predicate);
    }
}
