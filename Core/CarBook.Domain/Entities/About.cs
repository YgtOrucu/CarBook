using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class About : AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}
