using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
public class CreateBannerCommandHandle
{
    private readonly IRepository<Banner> _repository;

    public CreateBannerCommandHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBannerCommand command)
    {
        await _repository.CreateAsync(new Banner
        {
            Title = command.Title,
            Description = command.Description,
            CreatedDate = DateTime.Now,
            VideoUrl = command.VideoUrl,
            IsDeleted = false,
            CreatedBy = command.CreatedBy
        });
    }
}
