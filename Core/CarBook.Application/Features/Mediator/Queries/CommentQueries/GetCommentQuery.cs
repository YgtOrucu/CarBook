using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;

public record GetCommentQuery : IRequest<List<GetCommentQueryResult>>;
