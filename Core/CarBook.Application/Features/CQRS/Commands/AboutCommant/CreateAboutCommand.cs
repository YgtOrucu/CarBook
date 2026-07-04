using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommant;

public class CreateAboutCommand: AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
