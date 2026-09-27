using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands;

public record CreateCommentCommand(string NameSurname, string? ImageUrl, string MessageBody, int BlogId, string Email) : IRequest<object>;
