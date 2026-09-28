using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public class GenerateReservationMessageCommand : IRequest<BaseResult<GeneratedMessageCommand>>
{
    public string FullName { get; set; } = null!;
    public string CarName { get; set; } = null!;
    public string PickUpLocation { get; set; } = null!;
    public string DropOffLocation { get; set; } = null!;
    public string PickUpDateTime { get; set; } = null!;
    public string DropOffDateTime { get; set; } = null!;
    public string Price { get; set; } = null!;
}

public class GeneratedMessageCommand
{
    public string Message { get; set; } = null!;
}
