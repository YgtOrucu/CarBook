using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Read;

public class GetAuthorByIdQueryHandle(IRepository<Author> repository, IMapper mapper)
    : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
{
    public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetAuthorByIdQueryResult>(await repository.GetByIdAsync(request.Id));
    }
}
