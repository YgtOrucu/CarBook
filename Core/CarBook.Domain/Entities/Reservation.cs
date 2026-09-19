using CarBook.Domain.Entities.Comman;
using CarBook.Domain.Entities.Enums;

namespace CarBook.Domain.Entities;

public class Reservation : AuditableEntity
{
    public int CarId { get; set; }
    public Car? Car { get; set; }

    public int PickUpLocationId { get; set; }
    public Location? PickUpLocation { get; set; }

    public int DropOffLocationId { get; set; }
    public Location? DropOffLocation { get; set; }

    public DateTime PickUpDate { get; set; }
    public DateTime DropOffDate { get; set; }
    public TimeSpan PickUpTime { get; set; }
    public TimeSpan DropOffTime { get; set; }

    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

   
    public decimal TotalPrice { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    public string? Description { get; set; }
}