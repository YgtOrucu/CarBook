using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.WriteOperations;

public class UpdateTestimonialCommandHandle(IRepository<Testimonial> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTestimonialCommand, object>

{
    public async Task<object> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, values);
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The update was succesful",
            data = values
        };
    }
}
