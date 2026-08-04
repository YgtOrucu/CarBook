using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository(CarBookContext context) : ICarPricingRepository
{
    public async Task<List<GetCarPricingQueryResult>> GetGetCarPricingQueryResultsAsync()
    {
        var values = await context.CarPricings
            .Include(x => x.Car).Include(x => x.Pricing)
            .GroupBy(x => new
            {
                Model = x.Car!.Model,
                CoverImageUrl = x.Car.CoverImageUrl
            })
            .Select(y => new GetCarPricingQueryResult
            {
                Model = y.Key.Model,
                CoverImageUrl = y.Key.CoverImageUrl,
                CarPriceRates = y.Select(x => new CarPriceRatesResult
                {
                    Name = x.Pricing!.Name,
                    Amount = x.Amount
                })
            }).ToListAsync();

        return values;
    }
}
