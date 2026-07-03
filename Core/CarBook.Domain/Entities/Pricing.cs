using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Pricing : AuditableEntity
{
    public string? Name { get; set; }
    public ICollection<CarPricing> CarPricings { get; set; } = new List<CarPricing>();
}
