using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Events;
public record UserSendForgotPasswordCodeEvent(string Email, string resetCode) : INotification;