
using CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;
using FluentValidation;

namespace CarBook.Application.Features.Mediator.Validation.AskAssistantValidator;

public class AskAssistantCommandValidator : AbstractValidator<AskAssistantCommand>
{
    public AskAssistantCommandValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Mesaj boş olamaz.")
            .MaximumLength(1000).WithMessage("Mesaj çok uzun.");
    }
}
