using MediatR;

namespace ORG.TicketService.Application.Commands.CancelTicket;

public class CancelTicketRequest : IRequest<ResponseHandler>
{
    public CancelTicketRequest(int id)
    {
        Id = id;
    }

    public int Id { get; set; }

}