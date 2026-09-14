using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories;

public class CarDetailRepository(CarBookContext context) : ICarDetailRepository
{
    public async Task<GetCarDetailByCarIdResult> CarDetailByCarIdResultAsync(int carId)
    {
        var carDetail = await context.Cars
            .Include(c => c.Brand)
            .Include(c => c.CarFeatures)
            .ThenInclude(cf => cf.Feature)
            .Where(c => c.Id == carId)
            .Select(c => new GetCarDetailByCarIdResult
            {
                CarDetail = new CarDetail
                {
                    BrandName = c.Brand != null ? c.Brand.Name : null,
                    Model = c.Model,
                    CarKM = c.CarKM,
                    Transmission = c.Transmission,
                    SeatCount = c.SeatCount,
                    LuggageCount = c.LuggageCount,
                    Fuel = c.Fuel,
                    BigImageUrl = c.BigImageUrl
                },
                CarFeatures = c.CarFeatures.Select(cf => new CarFeature
                {
                    Name = cf.Feature != null ? cf.Feature.Name : null,
                    Available = cf.Available
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (carDetail == null)
        {
            return new GetCarDetailByCarIdResult();
        }

        carDetail.Cars = await context.Cars
            .Include(c => c.Brand)
            .Include(c => c.CarPricings)
            .ThenInclude(cp => cp.Pricing)
            .Where(y => !y.IsDeleted)
            .OrderByDescending(x => x.CarPricings.FirstOrDefault(p => p.PricingId == 5) != null ? x.CarPricings.FirstOrDefault(p => p.PricingId == 5).Amount : 0)
            .Take(3)
            .Select(c => new Cars
            {
                Id = c.Id,
                BrandName = c.Brand != null ? c.Brand.Name : null,
                Model = c.Model,
                CoverImageUrl = c.CoverImageUrl,
                CarAmount = c.CarPricings.FirstOrDefault(x => x.PricingId == 5) != null ? c.CarPricings.FirstOrDefault(x => x.PricingId == 5).Amount : 0,
                CarPricingName = c.CarPricings.FirstOrDefault(x => x.PricingId == 5) != null && c.CarPricings.FirstOrDefault(x => x.PricingId == 5).Pricing != null
                    ? c.CarPricings.FirstOrDefault(x => x.PricingId == 5).Pricing.Name
                    : string.Empty
            })
            .ToListAsync();

        return carDetail;
    }
}