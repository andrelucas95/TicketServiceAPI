using System.Net;
using MediatR;
using ORG.TicketService.Domain.UseCases;

namespace ORG.TicketService.Application.Commands.CancelTicket;

public class CancelTicketHandler : IRequestHandler<CancelTicketRequest, ResponseHandler>
{
    private readonly CancelTicketUseCase _useCase;

    public CancelTicketHandler(CancelTicketUseCase useCase)
    {
        _useCase = useCase;
    }

    public async Task<ResponseHandler> Handle(CancelTicketRequest request, CancellationToken cancellationToken)
    {
        var response = await _useCase.Execute(request.Id);

        return response.Success
            ? ResponseHandler.CreateSuccessResponse()
                .WithStatusCode(HttpStatusCode.NoContent)
            : ResponseHandler.CreateFailResponse()
                .WithStatusCode(HttpStatusCode.UnprocessableEntity)
                .WithMessages(response.Messages);
    }
}