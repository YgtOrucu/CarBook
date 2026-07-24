namespace CarBook.Application.Features.CQRS.Commands.BrandCommand;

public class UpdateBrandCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
