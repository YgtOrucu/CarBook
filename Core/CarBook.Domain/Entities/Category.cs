using CarBook.Domain.Entities.Comman;
namespace CarBook.Domain.Entities;

public class Category : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
