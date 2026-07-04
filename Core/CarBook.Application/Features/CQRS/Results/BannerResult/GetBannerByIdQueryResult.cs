using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Results.BannerResult;

public class GetBannerByIdQueryResult : AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}
