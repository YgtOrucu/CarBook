using CarBook.Application.Base;
using CarBook.Application.Exceptions;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Entities.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class DeleteReservationCommandHandle(IRepository<Reservation> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteReservationCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await repository.GetByIdAsync(request.Id);

        if (reservation == null)
        {
            return BaseResult<object>.Failure("Silinecek rezervasyon bulunamadı.");
        }
        reservation.Status = ReservationStatus.Cancelled;
        repository.Delete(reservation);
        var result = await unitOfWork.SaveChangeAsync();

        return BaseResult<object>.Success(result, "Rezervasyon başarıyla silindi.");
    }
}
