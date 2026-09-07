using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class UpdateCarPricingCommandHandler(ICarPricingRepository repository)
    : IRequestHandler<UpdateCarPricingCommand>
{
    public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateCarPricingAsync(
            request.CarId,
            request.HourlyAmount,
            request.DailyAmount,
            request.WeeklyAmount,
            request.MonthlyAmount
        );
    }
}