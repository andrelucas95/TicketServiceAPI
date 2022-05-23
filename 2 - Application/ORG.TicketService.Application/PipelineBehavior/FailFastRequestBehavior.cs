using MediatR;
using FluentValidation;
using FluentValidation.Results;
using ORG.TicketService.Application.Commands;

namespace ORG.TicketService.Application.PipelineBehavior;

public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : ResponseHandler
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();
        
        return failures.Any()
            ? Errors(failures)
            : next();
    }
    
    private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
    {
        var response = new ResponseHandler();

        foreach (var failure in failures)
        {
            response.AddMessage(failure.ErrorMessage);
        }

        return Task.FromResult(response as TResponse);
    }
}