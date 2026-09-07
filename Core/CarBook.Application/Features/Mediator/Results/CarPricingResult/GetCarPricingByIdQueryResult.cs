using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries;

public class GetCarPricingByIdQueryResult
{
    public int CarId { get; set; }
    public decimal HourlyAmount { get; set; }
    public decimal DailyAmount { get; set; }
    public decimal WeeklyAmount { get; set; }
    public decimal MonthlyAmount { get; set; }
}