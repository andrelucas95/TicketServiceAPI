using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ORG.TicketService.Data.Database;

public class DapperConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _configuration;
    private const string ConnectionStrings = "ConnectionStrings";
    private const string DefaultConnection = "DefaultConnection";

    public DapperConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration
            .GetSection(ConnectionStrings)
            .GetSection(DefaultConnection).Value;

        return new SqlConnection(connectionString);
    }
}