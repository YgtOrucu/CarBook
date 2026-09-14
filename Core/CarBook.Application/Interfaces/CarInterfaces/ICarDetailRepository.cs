using CarBook.Application.Features.CQRS.Results.CarResult;

namespace CarBook.Application.Interfaces.CarInterfaces;
public interface ICarDetailRepository
{
    Task<GetCarDetailByCarIdResult> CarDetailByCarIdResultAsync(int carId);
}
