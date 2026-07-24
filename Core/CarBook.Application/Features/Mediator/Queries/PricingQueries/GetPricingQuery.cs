using CarBook.Application.Features.Mediator.Results.PricingResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries;
public class GetPricingQuery:IRequest<List<GetPricingQueryResult>>
{
}
