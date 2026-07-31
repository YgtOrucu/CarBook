using CarBook.Application.Features.Mediator.Results.BlogTagResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogTagQueries
{
    public record GetTag4PieceForBlogDetailPageQuery(int BlogId) : IRequest<List<GetTag4PieceForBlogDetailPageQueryResult>>;
}
