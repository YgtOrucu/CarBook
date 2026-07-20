using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands;

public record RemoveFeatureCommand(int Id) : IRequest;
