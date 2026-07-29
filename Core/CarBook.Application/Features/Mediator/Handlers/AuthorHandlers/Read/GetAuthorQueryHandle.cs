using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read;

public class GetAuthorQueryHandle(IRepository<Author> repository, IMapper mapper)
    : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
{
    public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<List<GetAuthorQueryResult>>(await repository.GetAllAsync());
        return values;
    }
}
