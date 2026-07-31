using CarBook.Application.Features.Mediator.Results.BlogTagResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogTagQueries
{
    public record GetTagAllForBlogDetailPageQuery(int BlogId) : IRequest<List<GetTagAllForBlogDetailPageQueryResult>>;
}
