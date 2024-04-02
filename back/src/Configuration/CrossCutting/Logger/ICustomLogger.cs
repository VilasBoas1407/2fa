namespace TwoFactorAuthenticator.Dependency.Logger
{
    public interface ICustomLogger
    {
        Task LogInformation(string message);
        Task LogWarning(string message);
        Task LogError(string message);
        Task LogError(string message, Exception ex);
    }
}
