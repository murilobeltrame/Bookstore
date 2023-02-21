using Bookstore.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bookstore.DataTools
{
    internal sealed class MigrateTask: IHostedService
	{
        private readonly ILogger<MigrateTask> _logger;
        private readonly ApplicationContext _applicationContext;

        public MigrateTask(
            ILogger<MigrateTask> logger,
            IServiceScopeFactory factory)
		{
            _logger = logger;
            _applicationContext = factory
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationContext>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Running Migration ... ");
            _applicationContext.Database.Migrate();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Migration completed.");
            return Task.CompletedTask;
        }
    }
}

