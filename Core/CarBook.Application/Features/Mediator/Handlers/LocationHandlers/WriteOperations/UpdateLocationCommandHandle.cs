using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers.WriteOperations;

public class UpdateLocationCommandHandle(IRepository<Location> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateLocationCommand, object>
{
    public async Task<object> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        if (values == null)
        {
            throw new Exception("The updated value could not be found.");
        }

        mapper.Map(request, values);

        await unitOfWork.SaveChangeAsync();

        return new
        {
            success = true,
            messages = "The update process was succesful.",
            data = values
        };
    }
}
