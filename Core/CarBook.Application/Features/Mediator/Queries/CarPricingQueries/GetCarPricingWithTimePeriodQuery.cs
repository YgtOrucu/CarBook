using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
public record GetCarPricingWithTimePeriodQuery : IRequest<List<GetCarPricingWithTimePeriodQueryResult>>;