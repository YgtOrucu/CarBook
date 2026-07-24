namespace CarBook.Application.Features.CQRS.Commands.BannerCommand;

public class RemoveBannerCommand
{
    public int Id { get; set; }
    public RemoveBannerCommand(int id)
    {
        Id = id;
    }
}
