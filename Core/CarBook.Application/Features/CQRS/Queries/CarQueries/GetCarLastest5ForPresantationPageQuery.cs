using CarBook.Application.Features.CQRS.Results.CarResult;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries;

public record GetCarLastest5ForPresantationPageQuery : IRequest<List<GetCarLastest5ForPresantationPageResult>>;

