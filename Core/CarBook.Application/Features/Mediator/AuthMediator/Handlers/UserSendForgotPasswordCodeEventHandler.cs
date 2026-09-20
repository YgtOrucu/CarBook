using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;
public class UserSendForgotPasswordCodeEventHandler(ISendMailRepository emailService) : INotificationHandler<UserSendForgotPasswordCodeEvent>
{
    public async Task Handle(UserSendForgotPasswordCodeEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await emailService.SendForgotPasswordCode(notification.Email, notification.resetCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mail Hatası: {ex.Message}");
            throw;
        }
    }
}


