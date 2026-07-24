using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;

public class UpdateBannerCommandHandle(IRepository<Banner> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateBannerCommand commant)
    {
        _repository.Update(new Banner
        {
            Id = commant.Id,
            Title = commant.Title,
            Description = commant.Description,
            VideoUrl = commant.VideoUrl,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
