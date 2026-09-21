using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommand;

public record DeleteReservationCommand(int Id) : IRequest<BaseResult<object>>;
