using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.WriteOperations;

public class RemoveServicesCommandHandle(IRepository<Service> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveServicesCommand, object>
{
    public async Task<object> Handle(RemoveServicesCommand request, CancellationToken cancellationToken)
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
