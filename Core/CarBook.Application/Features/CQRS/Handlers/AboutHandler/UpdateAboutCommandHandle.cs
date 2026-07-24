using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class UpdateAboutCommandHandle(IUnitOfWork unitOfWork, IRepository<About> _repository)
{
    public async Task Handle(UpdateAboutCommand commant)
    {
        _repository.Update(new About
        {
            Id = commant.Id,
            Title = commant.Title,
            Description = commant.Description,
            ImageUrl = commant.ImageUrl,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
