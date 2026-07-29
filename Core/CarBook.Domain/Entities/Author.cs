using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
