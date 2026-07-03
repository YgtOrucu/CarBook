using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Testimonial : AuditableEntity
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
}
