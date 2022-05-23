using MediatR;

namespace ORG.TicketService.Application.Commands.FinishTicket;

public class FinishTicketRequest : IRequest<ResponseHandler>
{
    public FinishTicketRequest(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}