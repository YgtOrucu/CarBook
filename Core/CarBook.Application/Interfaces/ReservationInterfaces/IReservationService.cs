using CarBook.Application.Features.Mediator.Results.ReservationResult;

namespace CarBook.Application.Interfaces.ReservationInterfaces;
public interface IReservationService
{
    Task<List<GetReservationQueryResult>> GetAllListReservationAsync();
}
