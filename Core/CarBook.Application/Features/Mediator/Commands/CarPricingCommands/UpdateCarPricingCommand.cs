using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
public record UpdateCarPricingCommand(
    int CarId,
    decimal HourlyAmount,
    decimal DailyAmount,
    decimal WeeklyAmount,
    decimal MonthlyAmount
) : IRequest;