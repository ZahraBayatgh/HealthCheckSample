using System.Net;
using System.Net.Mail;

namespace HealthCheckSample.Services;

public class EmailService : IEmailService
{


    public Task SendEmailAsync(string recipient, string subject, string body)
    {
        //todo: send eamil
        return Task.CompletedTask;
    }
}