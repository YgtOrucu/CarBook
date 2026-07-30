using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;

public class Blog : AuditableEntity
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }

    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }

    public Author? Author { get; set; }
    public Category? Category { get; set; }

    public string Description { get; set; }

    public BlogDetail BlogDetail { get; set; }
}
