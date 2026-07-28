using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers.Read;

public class GetFooterAddressForPresantationPageQueryHandle(IRepository<FooterAddress> repository, IMapper mapper)
    : IRequestHandler<GetFooterAddressForPresantationPageQuery, GetFooterAddressForPresantationPageQueryResult>
{
    public async Task<GetFooterAddressForPresantationPageQueryResult> Handle(GetFooterAddressForPresantationPageQuery request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<GetFooterAddressForPresantationPageQueryResult>(repository.GetByQuery().FirstOrDefault()); 
        return value;
    }
}
