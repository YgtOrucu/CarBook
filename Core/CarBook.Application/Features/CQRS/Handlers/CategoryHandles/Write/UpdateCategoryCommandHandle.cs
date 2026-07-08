using CarBook.Application.Interfaces;
using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Write;

public class UpdateCategoryCommandHandle
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryCommandHandle(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        _repository.Update(new Category
        {
            Id = command.Id,
            Name = command.Name,
        });
    }
}
