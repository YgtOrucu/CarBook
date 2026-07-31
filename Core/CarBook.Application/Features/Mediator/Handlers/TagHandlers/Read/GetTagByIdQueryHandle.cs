using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using CarBook.Application.Features.Mediator.Results.TagResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers.Read;

public class GetTagByIdQueryHandle(IRepository<Tag> repository, IMapper mapper)
    : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
{
    public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetTagByIdQueryResult>(await repository.GetByIdAsync(request.Id));
    }
}
