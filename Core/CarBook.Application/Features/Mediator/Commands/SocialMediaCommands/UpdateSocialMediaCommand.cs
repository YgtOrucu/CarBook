using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;

public record UpdateSocialMediaCommand(int Id, string? Name, string? Icon, string? Url) : IRequest<object>;
