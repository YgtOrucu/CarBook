using CarBook.Application.Features.CQRS.Commands.AboutCommant;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class RemoveAboutCommandHandle
{
    private readonly IRepository<About> _repository;

    public RemoveAboutCommandHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAboutCommand about)
    {
        var entity = await _repository.GetByIdAsync(about.Id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }
}
