namespace CarBook.Application.Features.CQRS.Commands.AboutCommand;

public class RemoveAboutCommand
{
    public int Id { get; set; }

    public RemoveAboutCommand(int id)
    {
        Id = id;
    }
}
