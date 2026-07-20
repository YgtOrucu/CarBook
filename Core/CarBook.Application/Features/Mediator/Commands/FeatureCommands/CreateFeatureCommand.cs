using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands;

public class CreateFeatureCommand : IRequest<Unit>
{
    public string? Name { get; set; }
}
