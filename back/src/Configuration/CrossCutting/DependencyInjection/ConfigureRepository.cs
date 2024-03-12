using Microsoft.Extensions.DependencyInjection;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Infra.Mongo.Repository;
using TwoFactorAuthenticator.Infra.Redis.Factory;
using TwoFactorAuthenticator.Models.Factory;

namespace TwoFactorAuthenticator.Dependency.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();

            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}