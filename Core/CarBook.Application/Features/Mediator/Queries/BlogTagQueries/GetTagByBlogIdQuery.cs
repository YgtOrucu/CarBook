using CarBook.Application.Features.Mediator.Results.BlogTagResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogTagQueries
{
    public record GetTagByBlogIdQuery(int BlogId) : IRequest<List<GetTagByBlogIdQueryResult>>;
}
