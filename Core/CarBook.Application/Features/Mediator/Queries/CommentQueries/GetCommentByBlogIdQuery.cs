using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;

public record GetCommentByBlogIdQuery(int BlogId) : IRequest<List<GetCommentByBlogIdQueryResult>>;