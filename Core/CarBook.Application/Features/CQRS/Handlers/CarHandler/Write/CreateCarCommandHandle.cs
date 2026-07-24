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
            CarDetailsId = command.CarDetailsId,
            CoverImageUrl = command.CoverImageUrl,
            Model = command.Model,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
