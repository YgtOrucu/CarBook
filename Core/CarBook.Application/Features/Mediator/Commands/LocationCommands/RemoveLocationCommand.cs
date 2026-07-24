using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;
public record RemoveLocationCommand(int Id) : IRequest<object>;
