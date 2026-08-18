using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read;

public class GetFooterAddressQueryHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<GetFooterAddressQuery, GetFooterAddressQueryResult>
{
    public async Task<GetFooterAddressQueryResult> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
    {
        var footerAddress = mapper.Map<GetFooterAddressQueryResult>(repository.GetByQuery().FirstOrDefault());
        return footerAddress;
    }
}
