using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogsByCategoryQueryIdHandle(IBlogRepository repository, IMapper mapper)
    : IRequestHandler<GetBlogsByCategoryIdQuery, List<GetBlogsByCategoryIdQueryResult>>
{
    public async Task<List<GetBlogsByCategoryIdQueryResult>> Handle(GetBlogsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBlogsByCategoryIdAsync(request.Id);
    }
}
