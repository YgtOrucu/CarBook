using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommand;

public class UpdateBannerCommand :AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}
