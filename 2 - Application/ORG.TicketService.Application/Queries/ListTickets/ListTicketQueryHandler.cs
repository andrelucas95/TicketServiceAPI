using System.Net;
using MediatR;
using ORG.TicketService.Application.Commands.ListTickets;
using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.Application.Queries.ListTickets;

public class ListTicketQueryHandler :IRequestHandler<ListTicketQuery, ResponseHandler>
{
    private readonly ITicketRepository _ticketRepository;

    public ListTicketQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ResponseHandler> Handle(ListTicketQuery request, CancellationToken cancellationToken)
    {
        var tickets = await _ticketRepository.List();
        
        return ResponseHandler.CreateSuccessResponse()
            .WithStatusCode(HttpStatusCode.OK)
            .WithData(tickets); 
    }
}