using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries;

public record GetCarPricingByIdQuery(int CarId) : IRequest<GetCarPricingByIdQueryResult>;
