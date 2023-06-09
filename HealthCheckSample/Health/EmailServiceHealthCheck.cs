using System.Data;
using HealthCheckSample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckSample.Health
{
    public class EmailServiceHealthCheck : IHealthCheck
    {
        private readonly IEmailService _mailService;

        public EmailServiceHealthCheck(IEmailService mailService)
        {
            _mailService = mailService;
        }
      public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                await _mailService.SendEmailAsync("recipient@example.com", "Hello", "This is the email body.");
                return HealthCheckResult.Healthy();
            }
            catch (Exception exception)
            {
                // If any exception occurs during the health check, mark it as unhealthy with the exception details
                return HealthCheckResult.Unhealthy(exception.Message);
            }
            
        }
    }

}
