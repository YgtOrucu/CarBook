namespace CarBook.Dto.Dtos.ForAdminPageDtos.CarPricingSectionDtos;

public class ResultCarPricingWithTimePeriodDto
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