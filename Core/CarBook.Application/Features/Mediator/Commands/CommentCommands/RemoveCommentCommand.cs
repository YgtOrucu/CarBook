using MediatR;
namespace CarBook.Application.Features.Mediator.Commands.CommentCommands;

public record RemoveCommentCommand(int Id) : IRequest<object>;
