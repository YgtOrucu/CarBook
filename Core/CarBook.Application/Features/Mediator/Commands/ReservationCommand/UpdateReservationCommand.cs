using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public class UpdateReservationCommand : IRequest<BaseResult<object>>
{
    public int Id { get; set; }
    public DateTime PickUpDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan DropOffTime { get; set; }
}
