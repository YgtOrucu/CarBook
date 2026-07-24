using CarBook.Application.Features.Mediator.Results.LocationResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public record GetLocationByIdQuery(int Id) : IRequest<GetLocationByIdQueryResult>;
}
