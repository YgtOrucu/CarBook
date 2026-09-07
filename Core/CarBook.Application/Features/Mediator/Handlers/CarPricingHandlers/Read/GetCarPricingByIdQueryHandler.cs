using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class GetCarPricingByIdQueryHandler(ICarPricingRepository repository)
    : IRequestHandler<GetCarPricingByIdQuery, GetCarPricingByIdQueryResult>
{
    public async Task<GetCarPricingByIdQueryResult> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetCarPricingByCarIdAsync(request.CarId);
    }
}