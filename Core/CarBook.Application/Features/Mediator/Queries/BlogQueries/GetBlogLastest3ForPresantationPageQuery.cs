using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;

public record GetBlogLastest3ForPresantationPageQuery : IRequest<List<GetBlogLastest3ForPresantationPageQueryResult>>;
