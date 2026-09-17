using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Location : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Reservation> PickUpReservations { get; set; } = new List<Reservation>();
    public ICollection<Reservation> DropOffReservations { get; set; } = new List<Reservation>();
}
