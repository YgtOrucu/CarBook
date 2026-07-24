using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class CreateAboutCommandHandle(IRepository<About> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateAboutCommand about)
    {
        await _repository.CreateAsync(new About
        {
            Title = about.Title,
            Description = about.Description,
            ImageUrl = about.ImageUrl,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
