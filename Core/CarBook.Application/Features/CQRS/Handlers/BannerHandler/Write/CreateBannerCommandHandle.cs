using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
public class CreateBannerCommandHandle(IRepository<Banner> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateBannerCommand command)
    {
        await _repository.CreateAsync(new Banner
        {
            Title = command.Title,
            Description = command.Description,
            VideoUrl = command.VideoUrl,
        });

        await unitOfWork.SaveChangeAsync();

    }
}
