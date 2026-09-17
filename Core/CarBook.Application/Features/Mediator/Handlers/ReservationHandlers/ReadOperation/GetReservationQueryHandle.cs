using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResult;
using CarBook.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.ReadOperation;

public class GetReservationQueryHandle(IReservationService service) : IRequestHandler<GetReservationQuery, BaseResult<List<GetReservationQueryResult>>>
{
    public async Task<BaseResult<List<GetReservationQueryResult>>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var value = await service.GetAllListReservationAsync();
        return BaseResult<List<GetReservationQueryResult>>.Success(value);
    }
}
