using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Models.Response;

namespace TwoFactorAuthenticator.Models.Services
{
    public interface IUserService
    {
        public Task<Response<User>> InsertAsync(User user);
    }
}
