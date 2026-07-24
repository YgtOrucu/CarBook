using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.ReadOperations
{
    public class GetPricingByIdQueryHandle(IRepository<Pricing> repository, IMapper mapper)
    : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = mapper.Map<GetPricingByIdQueryResult>(await repository.GetByIdAsync(request.Id));
            return values;
        }
    }
}
