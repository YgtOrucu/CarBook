using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using CarBook.Application.Features.Mediator.Results.ServicesResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.ReadOperations;

public class GetServicesByIdQueryHandle(IRepository<Service> repository, IMapper mapper)
    : IRequestHandler<GetServicesByIdQuery, GetServicesByIdQueryResult>
{
    public async Task<GetServicesByIdQueryResult> Handle(GetServicesByIdQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<GetServicesByIdQueryResult>(await repository.GetByIdAsync(request.Id));
        return values;
    }
}
