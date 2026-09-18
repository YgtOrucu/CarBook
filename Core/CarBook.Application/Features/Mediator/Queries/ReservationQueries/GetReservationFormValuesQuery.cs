using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Results.ReservationResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ReservationQueries;

public class GetReservationFormValuesQuery() : IRequest<BaseResult<GetReservationFormValuesQueryResult>>
{
}
