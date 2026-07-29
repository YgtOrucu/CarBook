using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogQueryHandle(IBlogRepository repository, IMapper mapper)
    : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
{
    public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<GetBlogQueryResult>>(await repository.GetAllBlogsWithAuthorAndCategoryAsync());
    }
}
