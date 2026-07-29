using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogByIdQueryHandle(IBlogRepository repository, IMapper mapper)
    : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
{
    public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetBlogByIdQueryResult>(await repository.GetByIdBlogsWithAuthorAndCategoryAsync(request.Id));
    }
}
