namespace CarBook.Application.Features.CQRS.Commands.CarCommand;

public class RemoveCarCommand
{
    public int Id { get; set; }
    public RemoveCarCommand(int id)
    {
        Id = id;
    }
}
