namespace CarBook.Domain.Entities.Comman;

public abstract class BaseEntity
{
    public int Id { get; set; }
}

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}

