using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;

public class CreateCategoryCommandHandle(IRepository<Category> repository)
{
    public async Task Handle(CreateCategoryCommand command)
    {
        await repository.CreateAsync(new Category
        {
           Name = command.Name
        });
    }
}
