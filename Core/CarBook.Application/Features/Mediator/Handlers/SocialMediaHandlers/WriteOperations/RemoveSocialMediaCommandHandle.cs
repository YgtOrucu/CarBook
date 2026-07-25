using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers.WriteOperations;

public class RemoveSocialMediaCommandHandle(IRepository<SocialMedia> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveSocialMediaCommand, object>
{
    public async Task<object> Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
    {
        var deletedvalue = await repository.GetByIdAsync(request.Id);

        if (deletedvalue == null)
            throw new Exception("The deleted value could not be found");

        repository.Delete(deletedvalue);
        var result = await unitOfWork.SaveChangeAsync();
        return new
        {
            success = result,
            Message = "The deletion was successful",
            value = deletedvalue
        };
    }
}
