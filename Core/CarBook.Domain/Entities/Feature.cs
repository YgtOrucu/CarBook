using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Feature : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
}
