using CarBook.Application.Base;
using CarBook.Application.Features.CQRS.Results.CarResult;
using MediatR;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries;

public record GetCarDetailByCarIdQuery(int Id) : IRequest<BaseResult<GetCarDetailByCarIdResult>>;
