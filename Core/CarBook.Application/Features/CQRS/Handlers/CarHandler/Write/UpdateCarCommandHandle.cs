using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
public class UpdateCarCommandHandle(IRepository<Car> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateCarCommand command)
    {
        _repository.Update(new Car
        {
            Id = command.Id,
            BrandId = command.BrandId,
            CarDetailsId = command.CarDetailsId,
            CoverImageUrl = command.CoverImageUrl,
            Model = command.Model,
        });

        await unitOfWork.SaveChangeAsync();

    }
}
