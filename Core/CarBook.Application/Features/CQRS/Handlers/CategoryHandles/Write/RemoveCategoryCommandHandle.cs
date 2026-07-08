using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;

public class RemoveCategoryCommandHandle(IRepository<Category> repository)
{
    public async Task Handle(RemoveCategoryCommand command) 
    {
        var values = await repository.GetByIdAsync(command.id);

        if (values != null)
            repository.Delete(values);
    }
}
