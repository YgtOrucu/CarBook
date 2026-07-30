using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;

public class BlogDetail : BaseEntity
{
    public string MainTitle { get; set; }
    public string MainDescription { get; set; }
    public string SecondTitle { get; set; }
    public string SecondDescription { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }

    //public int CommentId { get; set; }
    //public Comment Comments { get; set; }
}
