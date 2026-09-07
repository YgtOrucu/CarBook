using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Car : AuditableEntity
{
    public int? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
    public ICollection<CarFeature> CarFeatures { get; set; } = new List<CarFeature>();
    public CarDescription? CarDescription { get; set; }
    public ICollection<CarPricing> CarPricings { get; set; } = new List<CarPricing>();
}
