using TwoFactorAuthenticator.Models.Entity;

namespace TwoFactorAuthenticator.Models.Services.Redis
{
    public interface ITokenService
    {
        Task<bool> CreateToken(string userId,Token token);
        Task<IList<Token>> GetTokenByUser(string userId);
    }
}
