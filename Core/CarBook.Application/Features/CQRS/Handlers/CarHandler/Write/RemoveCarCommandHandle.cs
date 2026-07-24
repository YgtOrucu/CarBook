using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
public class RemoveCarCommandHandle(IRepository<Car> repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(RemoveCarCommand command)
    {
        var entity = await repository.GetByIdAsync(command.Id);
        if (entity != null)
        {
            entity.IsDeleted = true;
            repository.Delete(entity);
        }
        await unitOfWork.SaveChangeAsync();
    }
}
