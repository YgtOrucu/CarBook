using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServicesHandlers.WriteOperations;

public class CreateServicesCommandHandle(IRepository<Service> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateServicesCommand, object>
{
    public async Task<object> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<Service>(request);
        await repository.CreateAsync(value);
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The addition was succesful",
            data = value
        };

    }
}
