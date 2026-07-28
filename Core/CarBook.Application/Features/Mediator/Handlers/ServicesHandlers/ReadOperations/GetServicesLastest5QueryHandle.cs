using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.ServicesQueries;
using CarBook.Application.Features.Mediator.Results.ServicesResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.ReadOperations;

public class GetServicesLastest5QueryHandle(IRepository<Service> repository, IMapper mapper)
    : IRequestHandler<GetServicesLastest5Query, List<GetServicesLastest5QueryResult>>
{
    public async Task<List<GetServicesLastest5QueryResult>> Handle(GetServicesLastest5Query request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<List<GetServicesLastest5QueryResult>>(repository.GetByQuery().Where(x=>!x.IsDeleted).OrderByDescending(x=>x.CreatedDate).Take(4).ToList());
        return value;
    }
}
