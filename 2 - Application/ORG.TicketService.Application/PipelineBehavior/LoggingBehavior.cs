using MediatR;
using Microsoft.Extensions.Logging;

namespace ORG.TicketService.Application.PipelineBehavior;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger _logger;

    public LoggingBehavior(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _logger.LogInformation($"Handling {typeof(TRequest).Name}");
        
        var response = await next();
        
        _logger.LogInformation($"Handled {typeof(TRequest).Name}");

        return response;
    }
}