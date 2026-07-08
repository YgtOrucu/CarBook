using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.CategoryCommand;

public class UpdateCategoryCommand : BaseEntity
{
    public string? Name { get; set; }
}
