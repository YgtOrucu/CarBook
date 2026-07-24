using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.ReadOperation;

public class GetLocationQueryHandle(IRepository<Location> repository, IMapper mapper)
    : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
{
    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<List<GetLocationQueryResult>>(await repository.GetAllAsync());
        return values;
    }
}
