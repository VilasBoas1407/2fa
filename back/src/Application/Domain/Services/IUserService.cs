using TwoFactorAuthenticator.Domain.Entity;
using TwoFactorAuthenticator.Domain.Model;

namespace TwoFactorAuthenticator.Models.Services
{
    public interface IUserService
    {
        public Task<ServiceResponse<User>> InsertAsync(User user);
    }
}
