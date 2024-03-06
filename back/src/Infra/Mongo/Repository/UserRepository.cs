using MongoDB.Driver;
using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Infra.Mongo.Context;

namespace TwoFactorAuthenticator.Infra.Mongo.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMongoCollection<User> _collection;

        public UserRepository(MongoDbContext dbContext) : base(dbContext)
        {
            _collection = dbContext.GetCollection<User>(typeof(User).Name);
        }

        public Task<bool> ExistEmail(string email)
            => _collection.Find(x => x.Email.Equals(email)).AnyAsync();

    }
}
