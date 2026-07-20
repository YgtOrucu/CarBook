using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;

public record GetFooterAddressByIdQuery(int id) : IRequest<GetFooterAddressByIdQueryResult>;
