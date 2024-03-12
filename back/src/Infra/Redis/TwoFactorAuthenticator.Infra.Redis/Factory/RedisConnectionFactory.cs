using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using TwoFactorAuthenticator.Models.Factory;

namespace TwoFactorAuthenticator.Infra.Redis.Factory
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly IConfiguration _config;

        public RedisConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public ConnectionMultiplexer Connection
        {
            get
            {
                string connectionString = _config.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connectionString);
            }
        }
    }
}
