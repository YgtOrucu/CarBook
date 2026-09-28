using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using FluentValidation;

namespace CarBook.Application.Features.Mediator.Validation.ReservationValidator;

public class SendReservationEmailCommandValidator : AbstractValidator<SendReservationEmailCommand>
{
    public SendReservationEmailCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
            .MaximumLength(3000).WithMessage("Mesaj çok uzun.");
    }
}
