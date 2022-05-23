using System.Net;
using MassTransit;
using MediatR;
using ORG.TicketService.Application.IntegrationEvents;
using ORG.TicketService.Domain.Repositories;
using ORG.TicketService.Domain.UseCases;

namespace ORG.TicketService.Application.Commands.FinishTicket;

public class FinishTicketHandler : IRequestHandler<FinishTicketRequest, ResponseHandler>
{
    private readonly FinishTicketUseCase _useCase;
    private readonly IBus _bus;
    private readonly ITicketRepository _ticketRepository;

    public FinishTicketHandler(FinishTicketUseCase useCase, IBus bus, ITicketRepository ticketRepository)
    {
        _useCase = useCase;
        _bus = bus;
        _ticketRepository = ticketRepository;
    }

    public async Task<ResponseHandler> Handle(FinishTicketRequest request, CancellationToken cancellationToken)
    {
        var response = await _useCase.Execute(request.Id);

        if (response.Success)
        {
            var ticket = await _ticketRepository.GetById(request.Id);
            // TODO: use mediatr
            await _bus.Publish<TicketFinishedEvent>(new TicketFinishedEvent(ticket.Title, ticket.FinishedAt.Value), cancellationToken);

            return ResponseHandler.CreateSuccessResponse()
                .WithStatusCode(HttpStatusCode.NoContent);
        }

        return ResponseHandler.CreateFailResponse()
                .WithStatusCode(HttpStatusCode.UnprocessableEntity)
                .WithMessages(response.Messages);
    }
}