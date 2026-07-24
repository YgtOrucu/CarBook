using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.ReadOperations;

public class GetPricingQueryHandle(IRepository<Pricing> repository, IMapper mapper)
    : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
{
    public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<List<GetPricingQueryResult>>(await repository.GetAllAsync());
        return value;
    }
}
