using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;

public record RemoveSocialMediaCommand(int Id) : IRequest<object>;
