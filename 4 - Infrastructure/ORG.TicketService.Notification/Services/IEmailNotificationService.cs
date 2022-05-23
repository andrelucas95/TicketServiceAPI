using ORG.TicketService.Notification.DTOs;

namespace ORG.TicketService.Notification.Services;

public interface IEmailNotificationService
{
    Task SendEmail(EmailData data);
}