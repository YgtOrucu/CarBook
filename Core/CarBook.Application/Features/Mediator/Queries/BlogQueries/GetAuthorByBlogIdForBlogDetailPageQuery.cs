using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries;
public record GetAuthorByBlogIdForBlogDetailPageQuery(int Id) : IRequest<GetAuthorByBlogIdForBlogDetailPageQueryResult>;

