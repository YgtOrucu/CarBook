using CarBook.Application.Features.Mediator.Results.ReservationResult;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.ReservationRepositories;

public class ReservationRepository(CarBookContext context) : IReservationService
{
    public async Task<List<GetReservationQueryResult>> GetAllListReservationAsync()
    {
        return await context.Reservations.Include(c => c.Car).Include(l => l.PickUpLocation).Include(l => l.DropOffLocation).Where(x => !x.IsDeleted).Select(y => new GetReservationQueryResult
        {
            CarName = y.Car.Brand.Name + " " + y.Car.Model,
            PickUpLocationName = y.PickUpLocation.Name,
            DropOffLocationName = y.DropOffLocation.Name,
            PickUpDate = y.PickUpDate,
            DropOffDate = y.DropOffDate,
            PickUpTime = y.PickUpTime,
            DropOffTime = y.DropOffTime,
            FullName = y.FullName,
            Email = y.Email
        }).ToListAsync();
    }

    public async Task<GetReservationFormValuesQueryResult> GetReservationFormValuesAsync()
    {
        var cars = await context.Cars.Where(x => !x.IsDeleted).Select(y => new GetCarDropdownDto
        {
            Id = y.Id,
            BrandName = y.Brand.Name,
            Model = y.Model
        }).ToListAsync();


        var locations = await context.Locations.Select(y => new GetLocationDropdownDto
        {
            Id = y.Id,
            Name = y.Name
        }).ToListAsync();

        return new GetReservationFormValuesQueryResult
        {
            Cars = cars,
            PickUpLocations = locations,
            DropOffLocations = locations
        };
    }
}
