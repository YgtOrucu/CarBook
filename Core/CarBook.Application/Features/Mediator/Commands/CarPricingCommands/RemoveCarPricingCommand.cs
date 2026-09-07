using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarPricingCommands;

public record RemoveCarPricingCommand(int Id) : IRequest<object>;