using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write;

public class CreateFeatureCommandHandler(IRepository<Feature> repository) : IRequestHandler<CreateFeatureCommand, Unit>
{
    public async Task<Unit> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new Feature
        {
            Name = request.Name,
        });

        return Unit.Value;
    }
}
