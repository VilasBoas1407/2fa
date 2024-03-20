using TwoFactorAuthenticator.Models.Entity;
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

        public bool CreateToken(Token userToken)
        {
            var key = Guid.NewGuid().ToString();
            var experationDate = DateTime.UtcNow.AddMinutes(5);
            return SetData(key, userToken, experationDate);
        }

        public Token GetTokenByUser(string userId)
        {
            return GetData<Token>(userId);
        }
    }
}
