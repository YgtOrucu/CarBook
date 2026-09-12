using MediatR;

namespace CarBook.Application.Features.Mediator.AuthMediator.Commands;

public class LogoutCommand : IRequest<string>
{
    public string UserId { get; set; } = string.Empty;
}
