using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read;

public class GetCarPricingQueryHandle(ICarPricingRepository repository)
    : IRequestHandler<GetCarPricingQuery, List<GetCarPricingQueryResult>>
{
    public async Task<List<GetCarPricingQueryResult>> Handle(GetCarPricingQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetGetCarPricingQueryResultsAsync();
    }
}
