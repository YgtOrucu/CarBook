using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogTagQueries;
using CarBook.Application.Features.Mediator.Results.BlogTagResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogTagHandlers.Read;

public class GetTagByBlogIdQueryHandle(IRepository<Blog> repository, IMapper mapper)
    : IRequestHandler<GetTagByBlogIdQuery, List<GetTagByBlogIdQueryResult>>
{
    public async Task<List<GetTagByBlogIdQueryResult>> Handle(GetTagByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var tagsbyBlogId = repository.GetByQuery().Where(x => x.Id == request.BlogId).SelectMany(x => x.Tags).Take(4).ToList();

        return mapper.Map<List<GetTagByBlogIdQueryResult>>(tagsbyBlogId);
    }
}
