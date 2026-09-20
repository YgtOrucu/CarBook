using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Events;

public record UserSendWelcomeEmailEvent(string Email, string UserName) : INotification;