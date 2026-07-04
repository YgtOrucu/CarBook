using CarBook.Application.Features.CQRS.Commands.AboutCommant;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandler;

public class UpdateAboutCommantHandle
{
    private readonly IRepository<About> _repository;

    public UpdateAboutCommantHandle(IRepository<About> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateAboutCommant commant)
    {
        _repository.Update(new About
        {
            Id = commant.Id,
            Title = commant.Title,
            Description = commant.Description,
            ImageUrl = commant.ImageUrl,
            CreatedBy = commant.CreatedBy,
            CreatedDate = commant.CreatedDate,
            UpdatedBy = commant.UpdatedBy,
            UpdatedDate = commant.UpdatedDate,
            IsDeleted = commant.IsDeleted
        });
    }
}
