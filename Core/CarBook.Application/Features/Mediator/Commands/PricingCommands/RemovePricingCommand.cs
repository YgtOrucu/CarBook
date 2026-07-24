using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands;

public record RemovePricingCommand(int Id) : IRequest<object>
{
}
