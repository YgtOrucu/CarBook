using CarBook.Application.Base;
using CarBook.Domain.Entities.Enums;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public class SendReservationEmailCommand : IRequest<BaseResult<bool>>
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Message { get; set; } = null!;
    public ReservationStatus Status { get; set; }
}
