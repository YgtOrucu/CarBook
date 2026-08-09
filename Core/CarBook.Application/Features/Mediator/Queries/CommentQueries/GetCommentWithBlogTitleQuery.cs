using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;
public class GetCommentWithBlogTitleQuery:IRequest<List<GetCommentWithBlogTitleQueryResult>>
{
}
