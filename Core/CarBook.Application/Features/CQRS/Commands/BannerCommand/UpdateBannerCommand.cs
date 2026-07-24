namespace CarBook.Application.Features.CQRS.Commands.BannerCommand;

public class UpdateBannerCommand
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}
