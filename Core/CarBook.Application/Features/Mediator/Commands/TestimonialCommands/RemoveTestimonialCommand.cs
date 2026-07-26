using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
public record RemoveTestimonialCommand(int Id) : IRequest<object>;
