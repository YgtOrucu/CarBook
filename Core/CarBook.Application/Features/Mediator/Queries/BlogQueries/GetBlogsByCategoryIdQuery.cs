using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public record GetBlogsByCategoryIdQuery(int Id) : IRequest<List<GetBlogsByCategoryIdQueryResult>>;
