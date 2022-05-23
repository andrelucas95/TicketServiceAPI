namespace ORG.TicketService.Notification.DTOs;

public class EmailData
{
    public EmailData(string from, string to, string subject, string content)
    {
        From = from;
        To = to;
        Subject = subject;
        Content = content;
    }

    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}