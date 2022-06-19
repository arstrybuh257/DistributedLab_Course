using System.Linq.Expressions;

namespace DuckCoin.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
