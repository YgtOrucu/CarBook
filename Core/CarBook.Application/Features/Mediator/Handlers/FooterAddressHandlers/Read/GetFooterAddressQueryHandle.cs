using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read;

public class GetFooterAddressQueryHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
{
    public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var footerAddress = mapper.Map<List<GetFooterAddressQueryResult>>(await repository.GetAllAsync());
        return footerAddress;
    }
}
