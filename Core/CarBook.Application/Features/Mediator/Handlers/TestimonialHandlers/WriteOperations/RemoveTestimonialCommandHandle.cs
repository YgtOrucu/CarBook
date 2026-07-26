using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.WriteOperations
{
    public class RemoveTestimonialCommandHandle(IRepository<Testimonial> repository, IUnitOfWork unitOfWork)
        : IRequestHandler<RemoveTestimonialCommand, object>
    {
        public async Task<object> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var deletedvalue = await repository.GetByIdAsync(request.Id);
            if (deletedvalue == null)
                throw new Exception("Deleted value could not be found");

            repository.Delete(deletedvalue);
            var result = await unitOfWork.SaveChangeAsync();

            return new
            {
                success = result,
                message = "The deletion was successful"
            };
        }
    }
}
