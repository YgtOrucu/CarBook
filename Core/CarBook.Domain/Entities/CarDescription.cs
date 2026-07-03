using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class CarDescription : AuditableEntity
{
    public string? Details { get; set; }
    public int CarId { get; set; }
    public Car? Car { get; set; }
}
