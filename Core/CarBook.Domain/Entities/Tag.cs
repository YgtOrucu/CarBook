using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;

public class Tag : BaseEntity
{
    public string TagName { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
