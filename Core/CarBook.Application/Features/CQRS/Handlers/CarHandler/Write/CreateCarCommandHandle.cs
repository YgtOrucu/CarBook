using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;

public class CreateCarCommandHandle(IRepository<Car> repository)
{
    public async Task Handle(CreateCarCommand command)
    {
        await repository.CreateAsync(new Car
        {
            Id = command.Id,
            BrandId = command.BrandId,
            CarDetailsId = command.CarDetailsId,
            CoverImageUrl = command.CoverImageUrl,
            CreatedBy = "System",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            Model = command.Model,
        });
    }
}
