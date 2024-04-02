using Microsoft.Extensions.Logging;

namespace TwoFactorAuthenticator.Dependency.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private readonly ILogger<CustomLogger> _logger;

        public CustomLogger(ILogger<CustomLogger> logger)
        {
            _logger = logger;
        }

        public Task LogInformation(string message)
        {
            _logger.LogInformation(message);
            return Task.CompletedTask;
        }

        public Task LogWarning(string message)
        {
            _logger.LogWarning(message);
            return Task.CompletedTask;
        }

        public Task LogError(string message)
        {
            _logger.LogError(message);
            return Task.CompletedTask;
        }
        public Task LogError(string message, Exception ex)
        {
            _logger.LogError(ex,message);
            return Task.CompletedTask;
        }
    }
}
