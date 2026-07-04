using CarBook.Application.Features.CQRS.Commands.AboutCommant;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class CreateAboutCommantHandle
{
    private readonly IRepository<About> _repository;

    public CreateAboutCommantHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateAboutCommant about)
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
