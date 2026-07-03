using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Brand : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
