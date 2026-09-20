using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResult;
using CarBook.Application.Interfaces.ReservationInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers.ReadOperation;

public class GetLoginUsersReservationQueryHandle(IReservationService service) : IRequestHandler<GetLoginUsersReservationQuery, BaseResult<List<GetLoginUsersReservationQueryResult>>>
{
    public async Task<BaseResult<List<GetLoginUsersReservationQueryResult>>> Handle(GetLoginUsersReservationQuery request, CancellationToken cancellationToken)
    {
        var value = await service.GetLoginUsersReservationAsync(request.Email);
        return BaseResult<List<GetLoginUsersReservationQueryResult>>.Success(value);
    }
}

