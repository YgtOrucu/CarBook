using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;

public class CreateBrandCommandHandle(IRepository<Brand> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateBrandCommand command)
    {
        await _repository.CreateAsync(new Brand
        {
            Name = command.Name,
        });
        await unitOfWork.SaveChangeAsync();
    }
}
