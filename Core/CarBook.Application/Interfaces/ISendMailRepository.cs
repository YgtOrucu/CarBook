namespace CarBook.Application.Interfaces;
public interface ISendMailRepository
{ 
    Task SendMailAsync(string ReceiverEmail, string ReceiverName, string ReplySubject, string ReplyMessage);
}
