using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write;

public class RemoveFeatureCommandHandler(IRepository<Feature> repository) : IRequestHandler<RemoveFeatureCommand>
{
    public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity != null)
        {
            repository.Delete(entity);
        }
    }
}
