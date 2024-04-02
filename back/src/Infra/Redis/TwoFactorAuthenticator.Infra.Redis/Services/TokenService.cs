using StackExchange.Redis;
using TwoFactorAuthenticator.Models.Entity;
using TwoFactorAuthenticator.Models.Factory;
using TwoFactorAuthenticator.Models.Services.Redis;

namespace TwoFactorAuthenticator.Infra.Redis.Services
{
    public class TokenService : ITokenService
    {
        private readonly IDatabase _database;
        private readonly string _key= "user:{0}:tokens";
        public TokenService(IRedisConnectionFactory redisConnectionFactory) 
        {

            var redis = redisConnectionFactory.Connection;
            _database = redis.GetDatabase();
        }

        public async Task<bool> CreateToken(string userId,Token token)
        {
            TimeSpan experationDate = TimeSpan.FromMinutes(5);
            try
            {
                string key = string.Format(_key, userId);
                await _database.HashSetAsync(key, token.Name, token.Value);
                await _database.KeyExpireAsync(userId, experationDate);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IList<Token>> GetTokenByUser(string userId)
        {
            string key = string.Format(_key,userId);
            HashEntry[] storedTokens = await _database.HashGetAllAsync(key);

            List<Token> tokenList = new();

            if (storedTokens.Length > 0)
            {
                foreach (var token in storedTokens)
                {
                    tokenList.Add(new Token(token.Name,token.Value.ToString()));
                }

            }

            return tokenList;
        }
    }
}
