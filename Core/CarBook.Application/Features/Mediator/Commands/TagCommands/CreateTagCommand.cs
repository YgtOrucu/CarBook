using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCommands;

public record CreateTagCommand(string TagName) : IRequest<object>;
