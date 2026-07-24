namespace CarBook.Application.Features.CQRS.Commands.CarCommand;

public class UpdateCarCommand
{
    public int Id { get; set; }
    public int? BrandId { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int? CarDetailsId { get; set; }
}

