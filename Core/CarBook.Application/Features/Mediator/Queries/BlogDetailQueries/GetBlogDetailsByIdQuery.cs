using CarBook.Application.Features.Mediator.Results.BlogDetailResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogDetailQueries;
public record GetBlogDetailsByIdQuery(int Id) : IRequest<GetBlogDetailsByIdQueryResult>;

