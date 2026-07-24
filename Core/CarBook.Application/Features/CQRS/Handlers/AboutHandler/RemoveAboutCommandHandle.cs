using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class RemoveAboutCommandHandle(IUnitOfWork unitOfWork, IRepository<About> _repository)
{
    public async Task Handle(RemoveAboutCommand about)
    {
        var entity = await _repository.GetByIdAsync(about.Id);
        if (entity != null)
        {
            _repository.Delete(entity);
            await unitOfWork.SaveChangeAsync();
        }
    }
}
