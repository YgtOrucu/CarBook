using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Results.ReservationResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ReservationQueries;

public record GetLoginUsersReservationQuery(string Email) : IRequest<BaseResult<List<GetLoginUsersReservationQueryResult>>>;
