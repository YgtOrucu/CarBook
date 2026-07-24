namespace CarBook.Application.Features.CQRS.Commands.BannerCommand;

public class CreateBannerCommand
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}


