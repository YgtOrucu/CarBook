namespace CarBook.Application.Features.Mediator.Results.CarPricingResult;

public class GetCarPricingQueryResult
{
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public IEnumerable<CarPriceRatesResult>? CarPriceRates { get; set; }
}

public class CarPriceRatesResult
{
    public string? Name { get; set; }
    public decimal? Amount { get; set; }

}
