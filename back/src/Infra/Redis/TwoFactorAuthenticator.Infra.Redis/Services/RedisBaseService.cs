using MongoDB.Bson.IO;
using StackExchange.Redis;
using System.Text.Json;
using TwoFactorAuthenticator.Infra.Redis.Factory;
using TwoFactorAuthenticator.Models.Factory;
using TwoFactorAuthenticator.Models.Services.Redis;

namespace TwoFactorAuthenticator.Infra.Redis.Services
{
    public class RedisBaseService : IRedisBaseService
    {
        private readonly IDatabase _database;

        public RedisBaseService(IRedisConnectionFactory redisConnectionFactory)
        {
            var redis = redisConnectionFactory.Connection;
            _database = redis.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _database.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.Subtract(DateTimeOffset.Now);
            var isSet = _database.StringSet(key, JsonSerializer.Serialize(value), expiryTime);
            return isSet;
        }
    }
}
