using TwoFactorAuthenticator.Infra.Mongo.Context;
using TwoFactorAuthenticator.Models.Entity;
using TwoFactorAuthenticator.Models.Repository;

namespace TwoFactorAuthenticator.Infra.Mongo.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MongoDbContext dbContext) : base(dbContext)
        { }
    }
}
