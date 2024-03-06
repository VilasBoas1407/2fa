using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using TwoFactorAuthenticator.Models.Services;

namespace TwoFactorAuthenticator.Dependency.DependecyInjection
{
    public class ConfigureService
    {
        public static void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
