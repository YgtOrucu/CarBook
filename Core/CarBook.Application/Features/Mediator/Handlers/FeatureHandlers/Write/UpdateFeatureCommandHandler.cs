using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write;

public class UpdateFeatureCommandHandler(IRepository<Feature> _repository) : IRequestHandler<UpdateFeatureCommand>
{
    public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        values.Name = request.Name;
        _repository.Update(values);
    }
}
