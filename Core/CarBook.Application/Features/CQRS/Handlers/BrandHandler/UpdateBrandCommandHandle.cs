using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;

public class UpdateBrandCommandHandle(IRepository<Brand> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateBrandCommand commant)
    {
        _repository.Update(new Brand
        {
            Id = commant.Id,
            Name = commant.Name,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
