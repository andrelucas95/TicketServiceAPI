using ORG.TicketService.Domain.Entities;
using ORG.TicketService.Domain.Enums;

namespace ORG.TicketService.Tests;

public class TicketTestsFixture : IDisposable
{
    private const string DefaultTitle = "Monitor não liga";
    private const string DefaultDescription = "Está conectado na energia, porém não liga.";
    public Ticket GenerateTicket()
    {
        return new Ticket(DefaultTitle, DefaultDescription, TicketPriorityType.Low);
    }

    public Ticket GenerateFinishedTicket()
    {
        var ticket = GenerateTicket();
        ticket.Finish(DateTime.Now);

        return ticket;
    }
    
    public Ticket GenerateCanceledTicket()
    {
        var ticket = GenerateTicket();
        ticket.Cancel(DateTime.Now);

        return ticket;
    }
    
    public void Dispose()
    {
    }
}