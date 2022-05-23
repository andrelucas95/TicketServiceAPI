using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ORG.TicketService.Application.Consumers;

namespace ORG.TicketService.Bootstrap.Configurations;

public static class MassTransitConfiguration
{
    public static void ConfigureMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(configurator =>
        {
            configurator.SetKebabCaseEndpointNameFormatter();
            const string applicationAssemblyName = "ORG.TicketService.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);
            configurator.AddConsumers(assembly);
            
            configurator.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                
                config.ConfigureEndpoints(context);
            });
        });
    }
}