using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;

namespace CarBook.Application.Interfaces.CarPricingInterfaces;
public interface ICarPricingRepository
{
    Task<List<GetCarPricingQueryResult>> GetGetCarPricingQueryResultsAsync();
    Task<GetCarPricingByIdQueryResult> GetCarPricingByCarIdAsync(int carId);
    Task <List<GetCarPricingWithTimePeriodQueryResult>> GetCarPricingWithTimePeriodAsync();
    Task UpdateCarPricingAsync(int carId, decimal hourly, decimal daily, decimal weekly, decimal monthly);
}
