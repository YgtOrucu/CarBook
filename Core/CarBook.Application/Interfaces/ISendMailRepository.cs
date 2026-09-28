namespace CarBook.Application.Interfaces;

public interface ISendMailRepository
{
    Task SendMailAsync(string ReceiverEmail, string ReceiverName, string ReplySubject, string ReplyMessage);
    Task SendWelcomeEmailAsync(string Email, string UserName);
    Task SendForgotPasswordCode(string Email, string resetCode);
    Task SendResetPassword(string Name, string Surname, string Email);
    Task SendReservationDetailsAsync(string toEmail, string subject, string message);
}
