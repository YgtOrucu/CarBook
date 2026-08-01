using CarBook.Application.Features.Mediator.Results.CommentResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries;

public record GetCommentByIdQuery(int Id) : IRequest<GetCommentByIdQueryResult>;
