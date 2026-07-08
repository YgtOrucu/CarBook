using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
public class UpdateCarCommandHandle
{
    private readonly IRepository<Car> _repository;

    public UpdateCarCommandHandle(IRepository<Car> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCarCommand command)
    {
        _repository.Update(new Car
        {
            Id = command.Id,
            BrandId = command.BrandId,
            CarDetailsId = command.CarDetailsId,
            CoverImageUrl = command.CoverImageUrl,
            UpdatedBy = "System",
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            Model = command.Model,
        });
    }
}
