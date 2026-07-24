using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.WriteOperations;

public class CreateLocationCommandHandle(IRepository<Location> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateLocationCommand, object>
{
    public async Task<object> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<Location>(request);

        await repository.CreateAsync(value);
        await unitOfWork.SaveChangeAsync();

        return new
        {
            success = true,
            messages = "The addition was success",
            data = value
        };
    }
}
