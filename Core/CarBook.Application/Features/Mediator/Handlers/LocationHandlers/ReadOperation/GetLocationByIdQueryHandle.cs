using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.ReadOperation;

public class GetLocationByIdQueryHandle(IRepository<Location> repository, IMapper mapper)
    : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<GetLocationByIdQueryResult>(await repository.GetByIdAsync(request.Id));
        return values;
    }
}
