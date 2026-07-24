using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.WriteOperations;

public class RemovePricingCommandHandle(IRepository<Pricing> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemovePricingCommand, object>
{
    public async Task<object> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
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
