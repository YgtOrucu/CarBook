using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogCountByCategoryPageQueryHandle(IBlogRepository repository)
    : IRequestHandler<GetBlogCountByCategoryQuery, List<GetBlogCountByCategoryQueryResult>>
{
    public async Task<List<GetBlogCountByCategoryQueryResult>> Handle(GetBlogCountByCategoryQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBlogCountByCategoryAsync();
    }
}
