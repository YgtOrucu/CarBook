using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetBlogLastest5ForPresantationPageQueryHandle(IBlogRepository repository, IMapper mapper)
    : IRequestHandler<GetBlogLastest5ForPresantationPageQuery, List<GetBlogLastest5ForPresantationPageQueryResult>>
{
    public async Task<List<GetBlogLastest5ForPresantationPageQueryResult>> Handle(GetBlogLastest5ForPresantationPageQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<GetBlogLastest5ForPresantationPageQueryResult>>(await repository.GetLast5BlogsWithRelationsAsync());
    }
}
