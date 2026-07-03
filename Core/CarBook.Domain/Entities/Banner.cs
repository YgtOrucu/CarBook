using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Banner : AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}
