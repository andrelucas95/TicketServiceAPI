using ORG.TicketService.Domain.Entities;

namespace ORG.TicketService.Domain.Repositories;

public interface ITicketRepository
{
    Task<bool> Add(Ticket ticket);
    Task<IEnumerable<Ticket>> List();
    Task<Ticket?> GetById(int id);
    Task<bool> Update(Ticket ticket);
}