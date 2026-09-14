namespace CarBook.Dto.Dtos.ForUsersPageDtos.CarSectionDtos;
public class GetCarDetailByCarIdDto
{
    public CarDetail CarDetail { get; set; }
    public IEnumerable<CarFeature> CarFeatures  { get; set; }
    public IEnumerable<Cars> Cars { get; set; }
}

public class Cars
{
    public int Id { get; set; }
    public string? BrandName { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public decimal CarAmount { get; set; }
    public string CarPricingName { get; set; }
}

public class CarFeature
{
    public string? Name { get; set; }
    public bool Available { get; set; }
}

public class CarDetail
{
    public string? BrandName { get; set; }
    public string? Model { get; set; }
    public int CarKM { get; set; }
    public int Transmission { get; set; }
    public byte SeatCount { get; set; }
    public byte LuggageCount { get; set; }
    public string? Fuel { get; set; }
    public string? BigImageUrl { get; set; }
}
