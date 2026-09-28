using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Commands.ReservationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Entities.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers;

public class SendReservationEmailCommandHandler(ISendMailRepository sendmailService, IRepository<Reservation> repository, IUnitOfWork unitOfWork)
: IRequestHandler<SendReservationEmailCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(
        SendReservationEmailCommand request, CancellationToken cancellationToken)
    {
        await sendmailService.SendReservationDetailsAsync(request.Email, "🚗 CarBook Rezervasyon Bilgilendirmesi", request.Message);
        var getReservation = await repository.GetByIdAsync(request.Id);
        getReservation.Status = ReservationStatus.Approved;

        repository.Update(getReservation);
        var result = await unitOfWork.SaveChangeAsync();
        return BaseResult<bool>.Success(result, "E-posta başarılı bir şekilde gönderilmiştir");
    }
}
