using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.ContactCommand;

public class UpdateContactCommand : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
    public DateTime? SendDate { get; set; }
}
