namespace CarBook.Dto.Dtos.ForUsersPageDtos.CarSectionDtos;
public class ResultCarLastest5Dto
{
    public int Id { get; set; }
    public string? BrandName { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
    public decimal CarAmount { get; set; }
    public string? CarPricingName { get; set; }
    public bool IsDeleted { get; set; }
}
