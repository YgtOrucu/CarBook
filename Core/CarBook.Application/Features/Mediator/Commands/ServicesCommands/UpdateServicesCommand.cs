using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServicesCommands;

public record UpdateServicesCommand(int Id, string? Title, string? Description, string IconUrl) : IRequest<object>;