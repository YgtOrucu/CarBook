namespace CarBook.Dto.Dtos.ForAdminPageDtos.CarPricingSectionDtos;

public class UpdateCarPricingDto
{
    public int CarId { get; set; }
    public decimal HourlyAmount { get; set; }
    public decimal DailyAmount { get; set; }
    public decimal WeeklyAmount { get; set; }
    public decimal MonthlyAmount { get; set; }
}