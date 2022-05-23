using ORG.TicketService.Application.Commands;
using ORG.TicketService.Domain.Entities;

namespace ORG.TicketService.Application.Queries.GetTicketById;

public class GetTicketByIdQueryResult
{
    public GetTicketByIdQueryResult(Ticket ticket)
    {
        Id = ticket.Id;
        Title = ticket.Title;
        Description = ticket.Description;
        OpenedAt = ticket.OpenedAt;
        FinishedAt = ticket.FinishedAt;
        CanceledAt = ticket.FinishedAt;
    }
    
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime OpenedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public DateTime? CanceledAt { get; set; }
}