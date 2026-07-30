using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogDetailQueries;
using CarBook.Application.Features.Mediator.Results.BlogDetailResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogDetailHandlers.Read;

public class GetBlogDetailsByIdQueryHandle(IRepository<BlogDetail> repository, IMapper mapper)
    : IRequestHandler<GetBlogDetailsByIdQuery, GetBlogDetailsByIdQueryResult>
{
    public async Task<GetBlogDetailsByIdQueryResult> Handle(GetBlogDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetBlogDetailsByIdQueryResult>(await repository.GetFilterAsync(x => x.BlogId == request.Id));
    }
}
