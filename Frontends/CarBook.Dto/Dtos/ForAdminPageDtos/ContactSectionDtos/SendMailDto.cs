namespace CarBook.Dto.Dtos.ForAdminPageDtos.ContactSectionDtos;
public class SendMailDto
{
    public int Id { get; set; }
    public string? ReceiverEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReplySubject { get; set; }
    public string? ReplyMessage { get; set; }
}
