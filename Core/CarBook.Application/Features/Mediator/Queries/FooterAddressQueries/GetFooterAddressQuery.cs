using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
