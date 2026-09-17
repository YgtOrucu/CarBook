using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public class CreateReservationCommand : IRequest<BaseResult<object>>
{
    public int CarId { get; set; }
    public int PickUpLocationId { get; set; }
    public int DropOffLocationId { get; set; }
    public string PickUpDate { get; set; }
    public string DropOffDate { get; set; }
    public string PickUpTime { get; set; }
    public string DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}
