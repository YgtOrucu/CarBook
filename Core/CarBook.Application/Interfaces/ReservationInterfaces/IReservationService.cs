using CarBook.Application.Features.Mediator.Results.ReservationResult;

namespace CarBook.Application.Interfaces.ReservationInterfaces;

public interface IReservationService
{
    Task<List<GetReservationQueryResult>> GetAllListReservationAsync();
    Task<GetReservationFormValuesQueryResult> GetReservationFormValuesAsync();
    Task<bool> isCarConflict(int carId, DateTime fullPickUpDateTime, DateTime fullDropOffDateTime);
    Task<bool> HasActiveReservationAsync(string Email);
}