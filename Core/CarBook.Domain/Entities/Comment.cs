using CarBook.Domain.Entities.Comman;

namespace CarBook.Domain.Entities;
public class Comment : AuditableEntity
{
    public string NameSurname { get; set; }
    public string MessageBody { get; set; }
    public string Email { get; set; }

    public int BlogId { get; set; }
    public Blog Blog  { get; set; }
}
