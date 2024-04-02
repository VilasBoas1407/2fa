using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TwoFactorAuthenticator.Dependency.Logger;
using TwoFactorAuthenticator.Infra.Redis.Services;
using TwoFactorAuthenticator.Models.Services;
using TwoFactorAuthenticator.Models.Services.Redis;

namespace TwoFactorAuthenticator.Dependency.DependecyInjection
{
    public class ConfigureService
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddSingleton<ICustomLogger, CustomLogger>();

            serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }
    }
}
