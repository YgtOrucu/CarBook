using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class CarDetails : BaseEntity
{
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
    public Car Car { get; set; } = null!;
}
