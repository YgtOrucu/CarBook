using MediatR;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers;

public class CreateCarPricingCommandHandler(IRepository<CarPricing> repository, IRepository<Pricing> pricingRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCarPricingCommand>
{
    public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
    {
        var pricings = await pricingRepository.GetAllAsync();

        var hourlyPricingId = pricings.FirstOrDefault(x => x.Name == "Saatlik")?.Id ?? 1;
        var dailyPricingId = pricings.FirstOrDefault(x => x.Name == "Günlük")?.Id ?? 2;
        var weeklyPricingId = pricings.FirstOrDefault(x => x.Name == "Haftalık")?.Id ?? 3;
        var monthlyPricingId = pricings.FirstOrDefault(x => x.Name == "Aylık")?.Id ?? 4;

        var carPricings = new List<CarPricing>
        {
            new() { CarId = request.CarId, PricingId = hourlyPricingId, Amount = request.HourlyAmount },
            new() { CarId = request.CarId, PricingId = dailyPricingId, Amount = request.DailyAmount },
            new() { CarId = request.CarId, PricingId = weeklyPricingId, Amount = request.WeeklyAmount },
            new() { CarId = request.CarId, PricingId = monthlyPricingId, Amount = request.MonthlyAmount }
        };

        foreach (var item in carPricings)
        {
            await repository.CreateAsync(item);
        }

        await unitOfWork.SaveChangeAsync();
    }
}