using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Service :AuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
}
