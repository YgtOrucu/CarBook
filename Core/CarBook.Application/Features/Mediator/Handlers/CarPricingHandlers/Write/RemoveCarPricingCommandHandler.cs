using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Write;

public class RemoveCarPricingCommandHandler(IRepository<CarPricing> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCarPricingCommand, object>
{
    public async Task<object> Handle(RemoveCarPricingCommand request, CancellationToken cancellationToken)
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