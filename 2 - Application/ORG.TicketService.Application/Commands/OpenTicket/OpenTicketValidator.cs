using FluentValidation;

namespace ORG.TicketService.Application.Commands.OpenTicket;

public class OpenTicketValidator : AbstractValidator<OpenTicketRequest>
{
    public OpenTicketValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title is required");
        
        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Description is required");
    }
}