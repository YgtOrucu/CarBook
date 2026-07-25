using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServicesCommands;

public record RemoveServicesCommand(int Id) : IRequest<object>;