using CarBook.Application.Features.Mediator.Results.CarPricingResult;

namespace CarBook.Application.Interfaces.CarPricingInterfaces;
public interface ICarPricingRepository
{
    Task<List<GetCarPricingQueryResult>> GetGetCarPricingQueryResultsAsync();
}
