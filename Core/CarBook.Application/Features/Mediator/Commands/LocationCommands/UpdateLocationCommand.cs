using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands;

public class UpdateLocationCommand : IRequest<object>
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
