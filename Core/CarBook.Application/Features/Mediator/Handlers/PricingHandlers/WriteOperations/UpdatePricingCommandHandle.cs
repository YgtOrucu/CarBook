using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.WriteOperations;

public class UpdatePricingCommandHandle(IRepository<Pricing> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePricingCommand, object>
{
    public async Task<object> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
    {
        var value = await repository.GetByIdAsync(request.Id);

        mapper.Map(request, value);
        var result = await unitOfWork.SaveChangeAsync();

        return new
        {
            success = result,
            messages = "The update was succesful",
            data = value
        };
    }
}
