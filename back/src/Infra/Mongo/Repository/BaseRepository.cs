using MongoDB.Driver;
using TwoFactorAuthenticator.Infra.Mongo.Context;
using TwoFactorAuthenticator.Models.Repository;

namespace TwoFactorAuthenticator.Infra.Mongo.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(MongoDbContext dbContext)
        {
            string collectionName = typeof(T).Name.Replace("Entity", "");
            _collection = dbContext.GetCollection<T>(collectionName);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
