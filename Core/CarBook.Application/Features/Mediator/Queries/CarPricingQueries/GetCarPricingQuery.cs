using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries;

public class GetCarPricingQuery : IRequest<List<GetCarPricingQueryResult>>
{
}
