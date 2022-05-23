using ORG.TicketService.Domain.Entities;

namespace ORG.TicketService.Application.Commands.ListTickets;

public class ListTicketResponse
{
    public ListTicketResponse(IEnumerable<Ticket> tickets)
    {
        Tickets = tickets.ToList();
    }
    
    public ICollection<Ticket> Tickets { get; set; }   
}