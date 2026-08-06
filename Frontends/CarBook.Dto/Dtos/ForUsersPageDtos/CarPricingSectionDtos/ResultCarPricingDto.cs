namespace CarBook.Dto.Dtos.ForUsersPageDtos.CarPricingSectionDtos;
public class ResultCarPricingDto
{
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public IEnumerable<CarPriceRatesDto>? CarPriceRates { get; set; }

}
public class CarPriceRatesDto
{
    public string? Name { get; set; }
    public decimal Amount { get; set; }
}

