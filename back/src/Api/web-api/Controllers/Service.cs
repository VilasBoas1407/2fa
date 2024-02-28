using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TwoFactorAuthenticator.Dependency.Settings;
using TwoFactorAuthenticator.Models.Entity;

namespace WebApi.Controllers
{
    public class Service
    {
        private readonly IMongoCollection<UserEntity> _usersCollection;

        public Service(
            IOptions<MongoDBSettings> mongoDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mongoDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<UserEntity>(
                mongoDatabaseSettings.Value.UsersCollections);
        }

        public async Task<List<UserEntity>> GetAsync() =>
            await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<UserEntity?> GetAsync(string id) =>
            await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserEntity newBook) =>
            await _usersCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, UserEntity updatedBook) =>
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}
