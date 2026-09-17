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
}
