using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;

public class UpdateBannerCommandHandle
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBannerCommand commant)
    {
        _repository.Update(new Banner
        {
            Id = commant.Id,
            Title = commant.Title,
            Description = commant.Description,
            CreatedBy = commant.CreatedBy,
            CreatedDate = commant.CreatedDate,
            UpdatedBy = commant.UpdatedBy,
            UpdatedDate = commant.UpdatedDate,
            IsDeleted = commant.IsDeleted
        });
    }
}
