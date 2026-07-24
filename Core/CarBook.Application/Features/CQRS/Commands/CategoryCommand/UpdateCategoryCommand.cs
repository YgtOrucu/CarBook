namespace CarBook.Application.Features.CQRS.Commands.CategoryCommand;

public class UpdateCategoryCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
