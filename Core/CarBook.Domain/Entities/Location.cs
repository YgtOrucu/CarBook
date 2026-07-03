using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Location : AuditableEntity
{
    public string? Name { get; set; }
}
