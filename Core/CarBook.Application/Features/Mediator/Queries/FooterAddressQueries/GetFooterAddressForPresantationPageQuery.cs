using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

public record GetFooterAddressForPresantationPageQuery : IRequest<GetFooterAddressForPresantationPageQueryResult>;

