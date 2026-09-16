using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;

public class Reservation : AuditableEntity
{
    public int CarId { get; set; }
    public Car? Car { get; set; }
    public int PickUpLocationId { get; set; }
    public int DropOffLocationId { get; set; }
    public string PickUpDate { get; set; }
    public string DropOffDate { get; set; }
    public string PickUpTime { get; set; }
    public string DropOffTime { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}
