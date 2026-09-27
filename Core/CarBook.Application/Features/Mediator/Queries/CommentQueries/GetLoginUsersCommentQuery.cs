using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;

public record GetLoginUsersCommentQuery(string userEmail) : IRequest<BaseResult<List<GetLoginUsersCommentQueryResult>>>
{
}
