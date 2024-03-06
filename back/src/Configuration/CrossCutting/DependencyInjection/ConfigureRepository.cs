using Microsoft.Extensions.DependencyInjection;
using TwoFactorAuthenticator.Domain.Repository;
using TwoFactorAuthenticator.Infra.Mongo.Repository;

namespace TwoFactorAuthenticator.Dependency.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }
    }
}