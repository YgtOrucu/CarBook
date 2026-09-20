using CarBook.Application.Features.Mediator.Results.ReservationResult;
using CarBook.Application.Interfaces.ReservationInterfaces;
using CarBook.Domain.Entities.Enums;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.ReservationRepositories;

public class ReservationRepository(CarBookContext context) : IReservationService
{
    public async Task<List<GetReservationQueryResult>> GetAllListReservationAsync()
    {
        return await context.Reservations.Include(c => c.Car).Include(l => l.PickUpLocation).Include(l => l.DropOffLocation).Where(x => !x.IsDeleted).Select(y => new GetReservationQueryResult
        {
            Id = y.Id,
            CarName = y.Car.Brand.Name + " " + y.Car.Model,
            PickUpLocationName = y.PickUpLocation.Name,
            DropOffLocationName = y.DropOffLocation.Name,
            PickUpDate = y.PickUpDate,
            DropOffDate = y.DropOffDate,
            PickUpTime = y.PickUpTime,
            DropOffTime = y.DropOffTime,
            FullName = y.FullName,
            Email = y.Email,
            Phone = y.Phone,
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

    public async Task<bool> isCarConflict(int carId, DateTime fullPickUpDateTime, DateTime fullDropOffDateTime)
    {

        var existingReservations = await context.Reservations
        .Where(x => x.CarId == carId && x.Status == ReservationStatus.Approved)
        .Select(x => new
        {
            PickUpDate = x.PickUpDate,
            PickUpTime = x.PickUpTime,
            DropOffDate = x.DropOffDate,
            DropOffTime = x.DropOffTime
        })
        .ToListAsync();

        bool isConflict = existingReservations.Any(r =>
        {
            DateTime existingStart = r.PickUpDate.Date + r.PickUpTime;
            DateTime existingEnd = r.DropOffDate.Date + r.DropOffTime;

            return fullPickUpDateTime < existingEnd && fullDropOffDateTime > existingStart;
        });

        return isConflict;
    }
    public async Task<bool> HasActiveReservationAsync(string Email)
    {
        var activeStatuses = new[] { ReservationStatus.Pending, ReservationStatus.Approved };

        return await context.Reservations
            .AnyAsync(x => x.Email == Email && activeStatuses.Contains(x.Status));
    }

    public async Task<List<GetLoginUsersReservationQueryResult>> GetLoginUsersReservationAsync(string Email)
    {
        return await context.Reservations.Include(c => c.Car).Include(l => l.PickUpLocation).Include(l => l.DropOffLocation).Where(x => !x.IsDeleted && x.Email == Email).Select(y => new GetLoginUsersReservationQueryResult
        {
            Id = y.Id,
            CarName = y.Car.Brand.Name + " " + y.Car.Model,
            PickUpLocationName = y.PickUpLocation.Name,
            DropOffLocationName = y.DropOffLocation.Name,
            PickUpDate = y.PickUpDate,
            DropOffDate = y.DropOffDate,
            PickUpTime = y.PickUpTime,
            DropOffTime = y.DropOffTime,
            Status = y.Status,
            Price = y.TotalPrice
        }).ToListAsync();
    }
}
