using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogLastest3ForPresantationPageQueryHandle(IBlogRepository repository, IMapper mapper)
    : IRequestHandler<GetBlogLastest3ForPresantationPageQuery, List<GetBlogLastest3ForPresantationPageQueryResult>>
{
    public async Task<List<GetBlogLastest3ForPresantationPageQueryResult>> Handle(GetBlogLastest3ForPresantationPageQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<GetBlogLastest3ForPresantationPageQueryResult>>(await repository.GetLast3BlogsWithRelationsAsync());
    }
}
