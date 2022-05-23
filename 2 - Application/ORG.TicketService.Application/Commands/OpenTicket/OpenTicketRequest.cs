using MediatR;
using ORG.TicketService.Domain.Entities;
using ORG.TicketService.Domain.Enums;

namespace ORG.TicketService.Application.Commands.OpenTicket;

public class OpenTicketRequest : IRequest<ResponseHandler>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TicketPriorityType Priority  { get; set; }

    public Ticket ToEntity()
    {
        return new Ticket(Title, Description, Priority);
    }
}