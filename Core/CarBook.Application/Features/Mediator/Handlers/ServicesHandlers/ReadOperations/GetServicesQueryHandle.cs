using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using CarBook.Application.Features.Mediator.Results.ServicesResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.ReadOperations;

public class GetServicesQueryHandle(IRepository<Service> repository, IMapper mapper)
    : IRequestHandler<GetServicesQuery, List<GetServicesQueryResult>>
{
    public async Task<List<GetServicesQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<List<GetServicesQueryResult>>(await repository.GetAllAsync());
        return value;
    }
}
