using MediatR;
namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;

public record CreateSocialMediaCommand(string? Name, string? Icon, string? Url) : IRequest<object>;
