using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.WriteOperations;

public class CreatePricingCommandHandle(IRepository<Pricing> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePricingCommand, object>
{
    public async Task<object> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
    {
        var value = mapper.Map<Pricing>(request);

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
