using System.Net;
using MediatR;
using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.Application.Commands.OpenTicket;

public class OpenTicketHandler : IRequestHandler<OpenTicketRequest, ResponseHandler>
{
    private readonly ITicketRepository _ticketRepository; 
        
    public OpenTicketHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<ResponseHandler> Handle(OpenTicketRequest request, CancellationToken cancellationToken)
    {
        var success = await _ticketRepository.Add(request.ToEntity());
        
        return success 
            ? ResponseHandler.CreateSuccessResponse().WithStatusCode(HttpStatusCode.OK)
            : ResponseHandler.CreateFailResponse().WithStatusCode(HttpStatusCode.BadRequest);
    }
}