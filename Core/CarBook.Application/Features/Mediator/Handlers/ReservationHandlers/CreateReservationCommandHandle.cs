using AutoMapper;
using CarBook.Application.Base;
using CarBook.Application.Exceptions;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System.Globalization;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class CreateReservationCommandHandle(
    IRepository<Reservation> repository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateReservationCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var culture = new CultureInfo("tr-TR");

        DateTime.TryParseExact(request.PickUpDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime pickUpDate);
        DateTime.TryParseExact(request.DropOffDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime dropOffDate);
        TimeSpan.TryParse(request.PickUpTime, out TimeSpan pickUpTime);
        TimeSpan.TryParse(request.DropOffTime, out TimeSpan dropOffTime);

        DateTime fullPickUpDateTime = pickUpDate.Date + pickUpTime;
        DateTime fullDropOffDateTime = dropOffDate.Date + dropOffTime;

        var existingReservations = repository.GetByQuery().Where(x => x.CarId == request.CarId);

        bool isCarConflict = false;

        foreach (var r in existingReservations)
        {
            if (DateTime.TryParseExact(r.PickUpDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime rPickDate) &&
                DateTime.TryParseExact(r.DropOffDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out DateTime rDropDate) &&
                TimeSpan.TryParse(r.PickUpTime, out TimeSpan rPickTime) &&
                TimeSpan.TryParse(r.DropOffTime, out TimeSpan rDropTime))
            {
                DateTime existingStart = rPickDate.Date + rPickTime;
                DateTime existingEnd = rDropDate.Date + rDropTime;

                if (fullPickUpDateTime < existingEnd && fullDropOffDateTime > existingStart)
                {
                    isCarConflict = true;
                    break;
                }
            }
        }

        if (isCarConflict)
        {
            throw new BadRequestException("Seçilen araç, belirtilen tarih ve saat aralığında başka bir rezervasyon nedeniyle dolu.");
        }

        var value = mapper.Map<Reservation>(request);
        await repository.CreateAsync(value);
        var result = await unitOfWork.SaveChangeAsync();

        return BaseResult<object>.Success(result, "Rezervasyon başarıyla oluşturuldu.En Kısa zamanda sizinle iletişime geçilecektir.");
    }
}