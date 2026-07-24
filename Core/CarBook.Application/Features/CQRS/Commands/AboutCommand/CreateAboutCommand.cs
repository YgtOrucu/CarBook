namespace CarBook.Application.Features.CQRS.Commands.AboutCommand;

public class CreateAboutCommand
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
