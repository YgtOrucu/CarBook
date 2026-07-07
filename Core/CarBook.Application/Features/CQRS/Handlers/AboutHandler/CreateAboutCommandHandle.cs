using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class CreateAboutCommandHandle
{
    private readonly IRepository<About> _repository;

    public CreateAboutCommandHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAboutCommand about)
    {
        await _repository.CreateAsync(new About
        {
            Title = about.Title,
            Description = about.Description,
            ImageUrl = about.ImageUrl,
            CreatedBy = about.CreatedBy,
            CreatedDate = DateTime.Now,
            IsDeleted = false,
        });
    }
}
