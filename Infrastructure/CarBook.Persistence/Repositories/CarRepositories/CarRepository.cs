using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarRepositories;

public class CarRepository(CarBookContext _context) : ICarRepository
{
    public async Task<List<Car>> GetCarsWithBrandAsync()
    {
        return await _context.Cars.AsNoTracking().Include(x => x.Brand).Include(x => x.CarDetails).ToListAsync();
    }
}
