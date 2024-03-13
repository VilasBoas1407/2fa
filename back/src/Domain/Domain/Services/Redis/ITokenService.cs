namespace TwoFactorAuthenticator.Models.Services.Redis
{
    public interface ITokenService
    {
        Task CreateToken();
        Task GetTokenByUser(string userId);
    }
}
