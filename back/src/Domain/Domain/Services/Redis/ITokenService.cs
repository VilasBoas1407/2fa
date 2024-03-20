using TwoFactorAuthenticator.Models.Entity;

namespace TwoFactorAuthenticator.Models.Services.Redis
{
    public interface ITokenService
    {
        bool CreateToken(Token userToken);
        Token GetTokenByUser(string userId);
    }
}
