namespace CarBook.Application.Base;

public abstract class BaseDto
{
    public int Id { get; set; }
}

public abstract class AuditableDto : BaseDto
{
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}
