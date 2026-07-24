using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;

public class CreateCategoryCommandHandle(IRepository<Category> repository,IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateCategoryCommand command)
    {
        await repository.CreateAsync(new Category
        {
           Name = command.Name
        });
        await unitOfWork.SaveChangeAsync();
    }
}
