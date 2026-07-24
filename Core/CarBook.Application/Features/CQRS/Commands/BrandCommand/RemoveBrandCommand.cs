namespace CarBook.Application.Features.CQRS.Commands.BrandCommand;

public class RemoveBrandCommand
{
    public int Id { get; set; }
    public RemoveBrandCommand(int id)
    {
        Id = id;
    }
}
