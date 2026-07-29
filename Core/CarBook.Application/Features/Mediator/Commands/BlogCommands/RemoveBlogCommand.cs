using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands;

public record RemoveBlogCommand(int Id) : IRequest<object>;
