using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands;

public record CreateCarPricingCommand(
    int CarId,
    decimal HourlyAmount,
    decimal DailyAmount,
    decimal WeeklyAmount,
    decimal MonthlyAmount
) : IRequest;