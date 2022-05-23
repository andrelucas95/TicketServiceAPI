using Microsoft.Extensions.Logging;
using ORG.TicketService.Notification.DTOs;

namespace ORG.TicketService.Notification.Services;

public class FakeEmailNotificationService : IEmailNotificationService
{
    private readonly ILogger<FakeEmailNotificationService> _logger;

    public FakeEmailNotificationService(ILogger<FakeEmailNotificationService> logger)
    {
        _logger = logger;
    }

    public Task SendEmail(EmailData data)
    {
        _logger.LogInformation($"Sending email to: {data.To} from: {data.From}, about: {data.Subject} with content: {data.Content}");
        return Task.CompletedTask;
    }
}