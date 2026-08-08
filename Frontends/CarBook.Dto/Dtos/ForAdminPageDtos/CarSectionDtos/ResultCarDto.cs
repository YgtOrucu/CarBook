namespace CarBook.Dto.Dtos.ForAdminPageDtos.CarSectionDtos;
public class ResultCarDto
{
    public int? BrandId { get; set; }
    public string? BrandName { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int? CarDetailsId { get; set; }
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
}
