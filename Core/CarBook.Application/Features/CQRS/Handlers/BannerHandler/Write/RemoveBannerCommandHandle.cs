using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
public class RemoveBannerCommandHandle(IRepository<Banner> _repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(RemoveBannerCommand Banner)
    {
        var entity = await _repository.GetByIdAsync(Banner.Id);
        if (entity != null)
        {
            _repository.Delete(entity);
        }

        await unitOfWork.SaveChangeAsync();

    }
}
