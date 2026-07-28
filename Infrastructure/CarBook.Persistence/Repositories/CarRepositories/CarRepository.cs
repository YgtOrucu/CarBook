using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories;

public class CarRepository(CarBookContext _context) : ICarRepository
{
    public async Task<List<Car>> GetCarForPresantationPageAsync()
    {
        return await _context.Cars.AsNoTracking().Include(x => x.Brand).Include(x => x.CarPricings).ThenInclude(x => x.Pricing).ToListAsync();
    }

    public async Task<List<Car>> GetCarLastest5ForPresantationPageAsync()
    {
        return await _context.Cars.AsNoTracking().Include(x => x.Brand).Include(x => x.CarPricings)
            .ThenInclude(x => x.Pricing)
            .Take(5).OrderByDescending(x => x.CarPricings.FirstOrDefault(x => x.PricingId == 5)!.Amount)
            .ToListAsync();
    }

    public async Task<List<Car>> GetCarsWithBrandAsync()
    {
        return await _context.Cars.AsNoTracking().Include(x => x.Brand).Include(x => x.CarDetails).ToListAsync();
    }
}
