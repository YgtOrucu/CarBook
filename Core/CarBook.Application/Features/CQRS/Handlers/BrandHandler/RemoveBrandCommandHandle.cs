using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;
public class RemoveBrandCommandHandle(IRepository<Brand> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(RemoveBrandCommand Brand)
    {
        var entity = await _repository.GetByIdAsync(Brand.Id);
        if (entity != null)
        {
            _repository.Delete(entity);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
