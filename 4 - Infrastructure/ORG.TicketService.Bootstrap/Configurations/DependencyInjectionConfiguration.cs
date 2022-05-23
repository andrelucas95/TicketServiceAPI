using Microsoft.Extensions.DependencyInjection;
using ORG.TicketService.Data.Database;
using ORG.TicketService.Data.Repositories;
using ORG.TicketService.Domain.Repositories;
using ORG.TicketService.Domain.UseCases;
using ORG.TicketService.Notification.Services;

namespace ORG.TicketService.Bootstrap.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        //Configuration
        services.AddScoped<IDbConnectionFactory, DapperConnectionFactory>();

        // Repositories
        services.AddScoped<ITicketRepository, TicketRepository>();
        
        // Use Cases
        services.AddScoped<FinishTicketUseCase>();
        services.AddScoped<CancelTicketUseCase>();
        
        // Infrastructure services
        services.AddScoped<IEmailNotificationService, FakeEmailNotificationService>();
    }
}