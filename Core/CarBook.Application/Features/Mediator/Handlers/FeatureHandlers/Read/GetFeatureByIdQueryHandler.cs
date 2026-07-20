using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Read;

public class GetFeatureByIdQueryHandler(IRepository<Feature> repository) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
{
    public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);

        return new GetFeatureByIdQueryResult
        {
            Id = values.Id,
            Name = values.Name,
        };
    }
}
