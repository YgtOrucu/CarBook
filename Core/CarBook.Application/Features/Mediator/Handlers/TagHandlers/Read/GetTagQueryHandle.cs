using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.TagQueries;
using CarBook.Application.Features.Mediator.Results.TagResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TagHandlers.Read;

public class GetTagQueryHandle(IRepository<Tag> repository, IMapper mapper)
    : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var value = await repository.GetAllAsync();

        if (value == null)
            throw new Exception("This data is empty");

        return mapper.Map<List<GetTagQueryResult>>(value);
    }
}
