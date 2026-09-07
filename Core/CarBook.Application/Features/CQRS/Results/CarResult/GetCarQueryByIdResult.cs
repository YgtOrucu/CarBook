using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Results.CarResult;
public class GetCarQueryByIdResult : BaseEntity
{
    public int? BrandId { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
}
