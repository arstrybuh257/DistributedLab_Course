using DuckCoin.DataAccess.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DuckCoin.DataAccess.Mongo
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : IIdentifiable
    {
        private IMongoCollection<TEntity> Collection { get; }

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            Collection = database.GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await GetAsync(e => e.Id == id).ConfigureAwait(false);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.Find(predicate).SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.Find(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Collection.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteOneAsync(e => e.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Collection.Find(predicate).AnyAsync().ConfigureAwait(false);
        }
    }
}
