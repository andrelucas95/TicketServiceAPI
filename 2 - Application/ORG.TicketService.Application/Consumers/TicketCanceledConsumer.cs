using MassTransit;
using ORG.TicketService.Application.IntegrationEvents;

namespace ORG.TicketService.Application.Consumers;

public class TicketCanceledConsumer : IConsumer<TicketCanceledEvent>
{
    public Task Consume(ConsumeContext<TicketCanceledEvent> context)
    {
        throw new NotImplementedException();
    }
}