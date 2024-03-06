using MongoDB.Bson;
using MongoDB.Driver;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Infra.Mongo.Context;

namespace TwoFactorAuthenticator.Infra.Mongo.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(MongoDbContext dbContext)
        {
            _collection = dbContext.GetCollection<T>(typeof(T).Name);
        }

        public async Task DeleteAsync(ObjectId id)
            => await _collection.DeleteOneAsync(x => x.Id == id);

        public Task<bool> ExistAsync(ObjectId id)
            => _collection.Find(x => x.Id == id).AnyAsync();

        public async Task<ICollection<T>> GetAllAsync()
            => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetByIdAsync(ObjectId id)
            => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        
        public async Task<T> InsertAsync(T item)
        {
            item.Id = ObjectId.GenerateNewId();
            item.CreatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(item);
            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            item.UpdatedAt = DateTime.UtcNow;

            await _collection.ReplaceOneAsync(x => x.Id == item.Id, item);

            return item;
        }
    }
}
