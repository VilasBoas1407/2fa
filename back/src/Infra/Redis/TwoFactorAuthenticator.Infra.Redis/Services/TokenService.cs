using TwoFactorAuthenticator.Models.Factory;
using TwoFactorAuthenticator.Models.Services.Redis;

namespace TwoFactorAuthenticator.Infra.Redis.Services
{
    public class TokenService : RedisBaseService, ITokenService
    {
        public TokenService(IRedisConnectionFactory redisConnectionFactory) 
            : base(redisConnectionFactory)
        {
        }

        public Task CreateToken()
        {
            throw new NotImplementedException();
        }

        public Task GetTokenByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
