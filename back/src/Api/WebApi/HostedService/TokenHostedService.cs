using TwoFactorAuthenticator.Dependency.Logger;

namespace WebApi.HostedService
{
    public class TokenHostedService : IHostedService
    {
        private readonly ICustomLogger _logger;
        public TokenHostedService(ICustomLogger logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _ = new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        public void ExecuteProcess(object state)
        {
            _logger.LogInformation("### Proccess executing ###");
            _logger.LogInformation($"{DateTime.Now}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("### Proccess stoping ###");
            _logger.LogInformation($"{DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}
