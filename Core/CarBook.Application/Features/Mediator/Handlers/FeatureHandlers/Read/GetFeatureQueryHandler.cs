using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Read;

public class GetFeatureQueryHandler(IRepository<Feature> repository) : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync();

        return values.Select(x => new GetFeatureQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
