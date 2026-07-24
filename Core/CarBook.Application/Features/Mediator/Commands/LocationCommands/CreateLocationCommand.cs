using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class CreateLocationCommand : IRequest<object>
{
    public string? Name { get; set; }
}
