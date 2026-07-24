using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands;

public class CreatePricingCommand : IRequest<object>
{
    public string? Name { get; set; }
}
