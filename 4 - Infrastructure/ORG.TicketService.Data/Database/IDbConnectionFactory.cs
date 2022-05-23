using System.Data;

namespace ORG.TicketService.Data.Database;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}