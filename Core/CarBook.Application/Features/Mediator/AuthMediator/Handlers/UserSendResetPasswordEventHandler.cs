using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class UserSendResetPasswordEventHandler(ISendMailRepository emailService) : INotificationHandler<UserSendResetPasswordEvent>
{
    public async Task Handle(UserSendResetPasswordEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await emailService.SendResetPassword(notification.Name, notification.Surname, notification.Email);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mail Hatası: {ex.Message}");
            throw;
        }
    }
}
