namespace CarBook.Application.Features.Mediator.Results.CarPricingResult;

public class GetCarPricingWithCarQueryResult
{
    public int CarPricingId { get; set; }
    public int CarId { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PricingName { get; set; } = string.Empty;
}

public class GetCarPricingWithTimePeriodQueryResult
{
    public int CarId { get; set; }
    public string BrandName { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public decimal HourlyAmount { get; set; }
    public decimal DailyAmount { get; set; }
    public decimal WeeklyAmount { get; set; }
    public decimal MonthlyAmount { get; set; }
}