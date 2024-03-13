using StackExchange.Redis;

namespace TwoFactorAuthenticator.Models.Factory
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection { get; }
    }
}
