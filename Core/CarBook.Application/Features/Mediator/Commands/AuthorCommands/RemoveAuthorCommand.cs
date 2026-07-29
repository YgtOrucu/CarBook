using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands;

public record RemoveAuthorCommand(int Id) : IRequest<object>;

