using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read;

public class GetFooterAddressByIdQueryHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
{
    public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<GetFooterAddressByIdQueryResult>(await repository.GetByIdAsync(request.id));
        return values;
    }
}
