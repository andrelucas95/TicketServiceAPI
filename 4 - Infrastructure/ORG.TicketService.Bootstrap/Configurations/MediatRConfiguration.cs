using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ORG.TicketService.Application.PipelineBehavior;

namespace ORG.TicketService.Bootstrap.Configurations;

public static class MediatRConfiguration
{
    public static void ConfigureMediatR(this IServiceCollection services)
    {
        const string applicationAssemblyName = "ORG.TicketService.Application";
        var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);
        
        AssemblyScanner
            .FindValidatorsInAssembly(assembly)
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        
        services.AddMediatR(assembly);
    }
}