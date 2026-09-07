using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;

public class UpdateCarCommandHandle(IRepository<Car> repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateCarCommand command)
    {
        var car = await repository.GetByIdAsync(command.Id);
        if (car != null)
        {
            car.BrandId = command.BrandId;
            car.Model = command.Model;
            car.CoverImageUrl = command.CoverImageUrl;
            car.BigImageUrl = command.BigImageUrl;
            car.CarKM = command.CarKM;
            car.Transmission = command.Transmission;
            car.SeatCount = command.SeatCount;
            car.LuggageCount = command.LuggageCount;
            car.Fuel = command.Fuel;

            repository.Update(car);
            await unitOfWork.SaveChangeAsync();
        }
    }
}