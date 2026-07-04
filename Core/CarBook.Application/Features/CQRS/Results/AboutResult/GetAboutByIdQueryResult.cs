using CarBook.Domain.Entities.Comman;
namespace CarBook.Application.Features.CQRS.Results.AboutResult;

public class GetAboutByIdQueryResult : AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
