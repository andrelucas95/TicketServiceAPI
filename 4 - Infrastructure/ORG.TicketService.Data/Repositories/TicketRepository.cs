using Dapper;
using ORG.TicketService.Data.Database;
using ORG.TicketService.Data.Database.Scripts;
using ORG.TicketService.Domain.Entities;
using ORG.TicketService.Domain.Repositories;

namespace ORG.TicketService.Data.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public TicketRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> Add(Ticket ticket)
    {
        var sql = TicketSql.INSERT_TICKET;
        var parameter = new
        {
            ticket.Title,
            ticket.Description,
            ticket.Priority,
            OpenedAt = DateTime.Now
        };
        
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, parameter);

            return rows > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Ticket>> List()
    {
        var sql = TicketSql.SELECT_ALL;
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            var tickets = await connection.QueryAsync<Ticket>(sql);

            return tickets.ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Ticket?> GetById(int id)
    {
        var sql = TicketSql.SELECT_TICKET_BY_ID;
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            var ticket = await connection.QueryFirstOrDefaultAsync<Ticket>(sql, new { id });

            return ticket;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Update(Ticket ticket)
    {
        var sql = TicketSql.UPDATE_TICKET;
        try
        {
            using var connection = _connectionFactory.CreateConnection();
            var param = new
            {
                ticket.Title,
                ticket.Description,
                ticket.Priority,
                ticket.FinishedAt,
                ticket.CanceledAt,
                ticket.Id
            };
            var rows = await connection.ExecuteAsync(sql, param);
            return rows > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}