using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AuthorizationService.Services.Contracts;

namespace AuthorizationService.BackgroundServices
{
    public class AuthorizationReversalService : BackgroundService
    {
        private readonly ILogger<AuthorizationReversalService> _logger;
        private readonly IServiceProvider _services;

        public AuthorizationReversalService(ILogger<AuthorizationReversalService> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Authorization reversal service is running.");


                using (var scope = _services.CreateScope())
                {
                    var authorizationRepository = scope.ServiceProvider.GetRequiredService<IAuthorizationRepository>();

           
                    var pendingAuthorizations = await authorizationRepository.GetPendingAuthorizationsAsync();


                    foreach (var authorization in pendingAuthorizations)
                    {
                        var TimeNow = DateTime.UtcNow;
                        var minutesDifference = TimeNow.Subtract((DateTime)authorization.RequestDate).TotalMinutes;
                     

                        if (minutesDifference > 5)
                        {
                        
                            await authorizationRepository.ReverseAuthorizationAsync(authorization);
                            _logger.LogInformation($"Authorization reversed for request id: {authorization.Id}");
                        }
                    }
                }

               
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
