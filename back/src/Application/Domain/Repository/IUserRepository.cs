using TwoFactorAuthenticator.Domain.Entity;

namespace TwoFactorAuthenticator.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    { 
        Task<bool> ExistEmail(string email);
    }
}
