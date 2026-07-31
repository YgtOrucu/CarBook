using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetAuthorByBlogIdForBlogDetailPageQueryHandle(IRepository<Blog> repository, IMapper mapper)
    : IRequestHandler<GetAuthorByBlogIdForBlogDetailPageQuery, GetAuthorByBlogIdForBlogDetailPageQueryResult>
{
    public async Task<GetAuthorByBlogIdForBlogDetailPageQueryResult> Handle(GetAuthorByBlogIdForBlogDetailPageQuery request, CancellationToken cancellationToken)
    {
        var values = repository.GetByQuery().Where(x => x.Id == request.Id).Select(y => y.Author).FirstOrDefault();
        if (values == null)
            throw new Exception("Value could not be found");

        return mapper.Map<GetAuthorByBlogIdForBlogDetailPageQueryResult>(values);
    }
}
