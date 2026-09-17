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

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad Soyad alanı boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Ad Soyad en fazla 100 karakter olmalıdır.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("E-posta adresi boş bırakılamaz.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x)
            .Must(x =>
            {
                bool isPickUpValid = DateTime.TryParseExact(x.PickUpDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime pDate);
                bool isDropOffValid = DateTime.TryParseExact(x.DropOffDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime dDate);
                bool isPickUpTimeValid = TimeSpan.TryParse(x.PickUpTime, out TimeSpan pTime);
                bool isDropOffTimeValid = TimeSpan.TryParse(x.DropOffTime, out TimeSpan dTime);

                if (!isPickUpValid || !isDropOffValid || !isPickUpTimeValid || !isDropOffTimeValid)
                    return false;

                DateTime fullPickUp = pDate.Date + pTime;
                DateTime fullDropOff = dDate.Date + dTime;

                if (fullPickUp < DateTime.Now) return false;
                if (fullDropOff <= fullPickUp) return false;

                return true;
            })
            .WithMessage("Geçersiz tarih/saat, geçmiş zamana rezervasyon yapılamaz veya iade zamanı alış zamanından önce/eşit olamaz.");
    }
}
