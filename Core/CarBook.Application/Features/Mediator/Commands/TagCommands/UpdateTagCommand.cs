using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCommands;

public record UpdateTagCommand(int Id, string TagName) : IRequest<object>;
