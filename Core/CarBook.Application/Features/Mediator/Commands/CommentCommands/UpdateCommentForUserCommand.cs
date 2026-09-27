using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands;

public record UpdateCommentForUserCommand(int Id, string MessageBody) : IRequest<BaseResult<object>>
{
}
