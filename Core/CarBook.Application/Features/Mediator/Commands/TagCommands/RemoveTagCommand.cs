using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCommands;

public record RemoveTagCommand(int Id) : IRequest<object>;
