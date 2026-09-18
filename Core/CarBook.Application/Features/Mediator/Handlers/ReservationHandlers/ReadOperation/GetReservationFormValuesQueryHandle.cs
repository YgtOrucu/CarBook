using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResult;
using CarBook.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.ReadOperation;

public class GetReservationFormValuesQueryHandle(IReservationService service)
    : IRequestHandler<GetReservationFormValuesQuery, BaseResult<GetReservationFormValuesQueryResult>>
{
    public async Task<BaseResult<GetReservationFormValuesQueryResult>> Handle(GetReservationFormValuesQuery request, CancellationToken cancellationToken)
    {
        var values = await service.GetReservationFormValuesAsync();
        return BaseResult<GetReservationFormValuesQueryResult>.Success(values);
    }
}
