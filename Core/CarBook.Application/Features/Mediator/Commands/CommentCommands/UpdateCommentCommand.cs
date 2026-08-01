using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands;

public record UpdateCommentCommand(int Id, string NameSurname, string? ImageUrl, string MessageBody, int BlogId) : IRequest<object>;
