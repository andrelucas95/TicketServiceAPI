namespace ORG.TicketService.Application.IntegrationEvents;

public record TicketFinishedEvent
{
    public TicketFinishedEvent(string title, DateTime finishedAt)
    {
        Title = title;
        FinishedAt = finishedAt;
    }

    public string Title { get; set; }
    public DateTime FinishedAt { get; set; }
}