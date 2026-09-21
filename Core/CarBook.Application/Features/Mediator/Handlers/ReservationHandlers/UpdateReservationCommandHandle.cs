using AutoMapper;
using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class UpdateReservationCommandHandle(IRepository<Reservation> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateReservationCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var updatedvalue = await repository.GetByIdAsync(request.Id);
        if (updatedvalue == null)
        {
            return BaseResult<object>.Failure("Güncellenecek rezervasyon bulunamadı.");
        }

        var oldPickUp = updatedvalue.PickUpDate.Date.Add(updatedvalue.PickUpTime);
        var oldDropOff = updatedvalue.DropOffDate.Date.Add(updatedvalue.DropOffTime);

        double oldTotalHours = (oldDropOff - oldPickUp).TotalHours;
        int oldDays = (int)Math.Ceiling(oldTotalHours / 24.0);
        if (oldDays < 1) oldDays = 1;

        decimal dailyPrice = updatedvalue.TotalPrice / oldDays;

        var newPickUp = request.PickUpDate.Date.Add(request.PickUpTime);
        var newDropOff = request.DropOffDate.Date.Add(request.DropOffTime);

        if (newDropOff <= newPickUp)
        {
            return BaseResult<object>.Failure("Bırakış tarihi ve saati, alış tarihinden sonra olmalıdır.");
        }

        double newTotalHours = (newDropOff - newPickUp).TotalHours;
        int newDays = (int)Math.Ceiling(newTotalHours / 24.0);
        if (newDays < 1) newDays = 1;

        mapper.Map(request, updatedvalue);

        updatedvalue.TotalPrice = newDays * dailyPrice;

        repository.Update(updatedvalue);
        var result = await unitOfWork.SaveChangeAsync();
        return BaseResult<object>.Success(result, "Rezervasyon başarıyla güncellendi.");
    }
}
