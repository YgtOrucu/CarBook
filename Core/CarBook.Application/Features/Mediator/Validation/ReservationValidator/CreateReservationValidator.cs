using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using FluentValidation;
using System.Globalization;

namespace CarBook.Application.Features.Mediator.Validation.ReservationValidator;

public class CreateReservationValidator : AbstractValidator<CreateReservationCommand>
{
    public CreateReservationValidator()
    {
        var culture = new CultureInfo("tr-TR");

        RuleFor(x => x.CarId).GreaterThan(0).WithMessage("Geçerli bir araç seçilmelidir.");

        RuleFor(x => x.PickUpLocationId).GreaterThan(0).WithMessage("Geçerli bir alış yeri seçilmelidir.");

        RuleFor(x => x.DropOffLocationId).GreaterThan(0).WithMessage("Geçerli bir iade yeri seçilmelidir.");

        RuleFor(x => x)
            .Must(x =>
            {
                DateTime fullPickUp = x.PickUpDate.Date + x.PickUpTime;
                DateTime fullDropOff = x.DropOffDate.Date + x.DropOffTime;

                if (fullPickUp < DateTime.Now) return false;
                if (fullDropOff <= fullPickUp) return false;

                return true;
            })
              .WithMessage("Geçersiz tarih/saat, geçmiş zamana rezervasyon yapılamaz veya iade zamanı alış zamanından önce/eşit olamaz.");

        RuleFor(x => x)
            .Must(x => x.PickUpDate.Date + x.PickUpTime >= DateTime.Now)
            .WithMessage("Geçmiş bir tarihe/saate rezervasyon yapılamaz.")
            .Must(x => (x.DropOffDate.Date + x.DropOffTime) > (x.PickUpDate.Date + x.PickUpTime))
            .WithMessage("İade zamanı, alış zamanından sonra olmalıdır.");
    }

}
