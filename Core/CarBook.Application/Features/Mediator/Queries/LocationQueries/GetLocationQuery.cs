using CarBook.Application.Features.Mediator.Results.LocationResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
}
