using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Events;

public record UserSendResetPasswordEvent(string Name, string Surname, string Email) : INotification;
