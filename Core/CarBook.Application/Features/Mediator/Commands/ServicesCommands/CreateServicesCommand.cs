using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServicesCommands;

public record CreateServicesCommand(string? Title, string? Description, string IconUrl) : IRequest<object>;