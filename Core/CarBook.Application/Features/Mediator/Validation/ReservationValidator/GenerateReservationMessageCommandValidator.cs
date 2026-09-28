using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using FluentValidation;

namespace CarBook.Application.Features.Mediator.Validation.ReservationValidator;
public class GenerateReservationMessageCommandValidator : AbstractValidator<GenerateReservationMessageCommand>
{
    public GenerateReservationMessageCommandValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CarName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PickUpLocation).NotEmpty().MaximumLength(150);
        RuleFor(x => x.DropOffLocation).NotEmpty().MaximumLength(150);
        RuleFor(x => x.PickUpDateTime).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DropOffDateTime).NotEmpty().MaximumLength(50);
    }
}