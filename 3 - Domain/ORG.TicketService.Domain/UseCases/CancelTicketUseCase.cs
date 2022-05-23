using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.Domain.UseCases;

public class CancelTicketUseCase
{
    private readonly ITicketRepository _ticketRepository;

    public CancelTicketUseCase(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }
    
    public async Task<DomainResponseHandler> Execute(int ticketId)
    {
        var ticket = await _ticketRepository.GetById(ticketId);
        
        if (ticket is null) return DomainResponseHandler.CreateFailResponse().WithMessage("Ticket not found");
        if (!ticket.CanAct("cancel")) return DomainResponseHandler.CreateFailResponse().WithMessage("Invalid action");
        
        ticket.Cancel(DateTime.Now);

        var success = await _ticketRepository.Update(ticket);
        
        return  success 
            ? DomainResponseHandler.CreateSuccessResponse()
            : DomainResponseHandler.CreateFailResponse();
    }
}