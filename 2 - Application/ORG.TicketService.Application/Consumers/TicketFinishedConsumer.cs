using MassTransit;
using ORG.TicketService.Application.IntegrationEvents;
using ORG.TicketService.Notification.DTOs;
using ORG.TicketService.Notification.Services;

namespace ORG.TicketService.Application.Consumers;

public class TicketFinishedConsumer : IConsumer<TicketFinishedEvent>
{
    private const string DefaultUserMailAddress = "user.fake@email.adress.com";
    private const string DefaultOrgMailAddress = "org.fake@no-reply.com";
    private readonly IEmailNotificationService _emailNotificationService;

    public TicketFinishedConsumer(IEmailNotificationService emailNotificationService)
    {
        _emailNotificationService = emailNotificationService;
    }

    public async Task Consume(ConsumeContext<TicketFinishedEvent> context)
    {
        var subject = $"Ticket: {context.Message.Title} has finished";
        var content = $"Your ticket has finished at {context.Message.FinishedAt}, we hope to have helped.";
        var emailData = new EmailData(DefaultOrgMailAddress, DefaultUserMailAddress, subject, content);

        await _emailNotificationService.SendEmail(emailData);
    }
}