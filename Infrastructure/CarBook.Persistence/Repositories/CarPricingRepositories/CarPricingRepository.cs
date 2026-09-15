using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories;

public class CarPricingRepository(CarBookContext context) : ICarPricingRepository
{
    public async Task<GetCarPricingByIdQueryResult> GetCarPricingByCarIdAsync(int carId)
    {
        var pricings = await context.CarPricings
        .Include(x => x.Pricing)
        .Where(x => x.CarId == carId)
        .ToListAsync();

        return new GetCarPricingByIdQueryResult
        {
            CarId = carId,
            HourlyAmount = pricings.FirstOrDefault(x => x.Pricing.Name == "Saatlik")?.Amount ?? 0,
            DailyAmount = pricings.FirstOrDefault(x => x.Pricing.Name == "Günlük")?.Amount ?? 0,
            WeeklyAmount = pricings.FirstOrDefault(x => x.Pricing.Name == "Haftalık")?.Amount ?? 0,
            MonthlyAmount = pricings.FirstOrDefault(x => x.Pricing.Name == "Aylık")?.Amount ?? 0
        };
    }

    public async Task<List<GetCarPricingWithTimePeriodQueryResult>> GetCarPricingWithTimePeriodAsync()
    {
        var values = await context.CarPricings
            .Include(x => x.Car)
            .ThenInclude(x => x.Brand)
            .Include(x => x.Pricing)
            .Where(x => !x.Car.IsDeleted)
            .GroupBy(x => new { x.CarId, x.Car.Brand.Name, x.Car.Model, x.Car.CoverImageUrl })
            .Select(g => new GetCarPricingWithTimePeriodQueryResult
            {
                CarId = g.Key.CarId,
                BrandName = g.Key.Name,
                Model = g.Key.Model ?? "",
                CoverImageUrl = g.Key.CoverImageUrl ?? "",
                HourlyAmount = g.Where(x => x.Pricing.Name == "Saatlik").Select(x => x.Amount).FirstOrDefault(),
                DailyAmount = g.Where(x => x.Pricing.Name == "Günlük").Select(x => x.Amount).FirstOrDefault(),
                WeeklyAmount = g.Where(x => x.Pricing.Name == "Haftalık").Select(x => x.Amount).FirstOrDefault(),
                MonthlyAmount = g.Where(x => x.Pricing.Name == "Aylık").Select(x => x.Amount).FirstOrDefault(),
            }).ToListAsync();

        return values;
    }

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

    public async Task UpdateCarPricingAsync(int carId, decimal hourly, decimal daily, decimal weekly, decimal monthly)
    {
        var pricings = await context.CarPricings
         .Include(x => x.Pricing)
         .Where(x => x.CarId == carId)
         .ToListAsync();

        foreach (var item in pricings)
        {
            switch (item.Pricing.Name)
            {
                case "Saatlik": item.Amount = hourly; break;
                case "Günlük": item.Amount = daily; break;
                case "Haftalık": item.Amount = weekly; break;
                case "Aylık": item.Amount = monthly; break;
            }
        }

        await context.SaveChangesAsync();
    }
}
