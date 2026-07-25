using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.WriteOperations;

public class UpdateServicesCommandHandle(IRepository<Service> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateServicesCommand, object>
{
    public async Task<object> Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
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
