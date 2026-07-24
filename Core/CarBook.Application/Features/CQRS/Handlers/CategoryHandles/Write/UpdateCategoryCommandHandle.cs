using CarBook.Application.Interfaces;
using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;

public class UpdateCategoryCommandHandle(IRepository<Category> repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateCategoryCommand command)
    {
        repository.Update(new Category
        {
            Id = command.Id,
            Name = command.Name,
        });
        await unitOfWork.SaveChangeAsync();
    }
}
