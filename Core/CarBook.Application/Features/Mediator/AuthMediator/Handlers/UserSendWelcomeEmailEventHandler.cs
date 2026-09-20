using CarBook.Application.Features.Mediator.AuthMediator.Events;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Handlers;

public class UserSendWelcomeEmailEventHandler(ISendMailRepository emailService) : INotificationHandler<UserSendWelcomeEmailEvent>
{
    public async Task Handle(UserSendWelcomeEmailEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            await emailService.SendWelcomeEmailAsync(notification.Email, notification.UserName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Mail Hatası: {ex.Message}");
            throw;
        }
    }
}