namespace CarBook.Application.Features.CQRS.Commands.ContactCommand;

public class UpdateContactCommand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
    public DateTime? SendDate { get; set; }
    public bool IsStatus { get; set; }
}
