using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.WriteOperations;

public class CreateTestimonialCommandHandle(IRepository<Testimonial> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTestimonialCommand, object>
{
    public async Task<object> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(mapper.Map<Testimonial>(request));
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The addition was succesful",
        };
    }
}
