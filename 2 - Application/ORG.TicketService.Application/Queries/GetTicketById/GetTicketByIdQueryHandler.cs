using System.Net;
using MediatR;
using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.Application.Queries.GetTicketById;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, ResponseHandler>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ResponseHandler> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _ticketRepository.GetById(request.Id);

        if (ticket is null) return ResponseHandler
            .CreateFailResponse()
            .WithStatusCode(HttpStatusCode.NotFound)
            .WithMessage("Ticket not found.");
        
        var data = new GetTicketByIdQueryResult(ticket);

        return ResponseHandler
            .CreateSuccessResponse()
            .WithStatusCode(HttpStatusCode.OK)
            .WithData(data);
    }
}