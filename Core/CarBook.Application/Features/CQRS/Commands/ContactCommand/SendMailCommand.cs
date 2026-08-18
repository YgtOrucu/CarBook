using MediatR;

namespace CarBook.Application.Features.CQRS.Commands.ContactCommand;

public class SendMailCommand : IRequest<string>
{
    public string? ReceiverEmail { get; set; }
    public string? ReceiverName { get; set; }
    public string? ReplySubject { get; set; }
    public string? ReplyMessage { get; set; }
}
