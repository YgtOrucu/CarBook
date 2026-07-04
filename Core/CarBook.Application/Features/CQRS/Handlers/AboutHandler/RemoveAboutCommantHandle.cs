using CarBook.Application.Features.CQRS.Commands.AboutCommant;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class RemoveAboutCommantHandle
{
    private readonly IRepository<About> _repository;

    public RemoveAboutCommantHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveAboutCommant about)
    {
        var entity = await _repository.GetByIdAsync(about.Id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }
    }
}
