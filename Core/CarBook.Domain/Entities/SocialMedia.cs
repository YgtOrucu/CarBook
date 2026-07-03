using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class SocialMedia : AuditableEntity
{
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string? Url { get; set; }
}
