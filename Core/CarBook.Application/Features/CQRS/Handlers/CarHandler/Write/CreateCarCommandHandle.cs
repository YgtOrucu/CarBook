using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;

public class CreateCarCommandHandle(IRepository<Car> repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateCarCommand command)
    {
        await repository.CreateAsync(new Car
        {
            BrandId = command.BrandId,
            Model = command.Model,
            CoverImageUrl = command.CoverImageUrl,
            BigImageUrl = command.BigImageUrl,
            CarKM = command.CarKM,
            Transmission = command.Transmission,
            SeatCount = command.SeatCount,
            LuggageCount = command.LuggageCount,
            Fuel = command.Fuel
        });

        await unitOfWork.SaveChangeAsync();
    }
}