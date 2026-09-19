using AutoMapper;
using CarBook.Application.Base;
using CarBook.Application.Exceptions;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class CreateReservationCommandHandler(
    IRepository<Reservation> repository,
    IReservationService service,
    ICarPricingRepository carPricing,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateReservationCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        DateTime fullPickUpDateTime = request.PickUpDate.Date + request.PickUpTime;
        DateTime fullDropOffDateTime = request.DropOffDate.Date + request.DropOffTime;

        bool isCarConflict = await service.isCarConflict(request.CarId, fullPickUpDateTime, fullDropOffDateTime);

        if (isCarConflict)
        {
            throw new BadRequestException("Seçilen araç, belirtilen tarih ve saat aralığında başka bir rezervasyon nedeniyle dolu.");
        }

        bool hasActiveReservation = await service.HasActiveReservationAsync(request.Email);

        if (hasActiveReservation)
        {
            throw new BadRequestException("Devam eden veya onay bekleyen bir rezervasyonunuz bulunmaktadır. Mevcut rezervasyonunuz tamamlanmadan yeni bir talep oluşturamazsınız.");
        }

        var reservation = mapper.Map<Reservation>(request);
        var selectedCarPricing = await carPricing.GetCarPricingByCarIdAsync(request.CarId);
        reservation.TotalPrice = request.CalculateTotalPrice(selectedCarPricing.DailyAmount);
        await repository.CreateAsync(reservation);
        var result = await unitOfWork.SaveChangeAsync();

        return BaseResult<object>.Success(result, "Rezervasyon başarıyla oluşturuldu. En kısa zamanda sizinle iletişime geçilecektir.");
    }
}