using CarBook.Application.Features.CQRS.Results.BannerResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
public class GetBannerQueryHandle
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }
    public async Task<GetBannerQueryResult> Handle()
    {
        var banners = _repository.GetByQuery().FirstOrDefault();

        return new GetBannerQueryResult
        {
            Id = banners.Id,
            Title = banners.Title,
            Description = banners.Description,
            VideoUrl = banners.VideoUrl,
            CreatedDate = banners.CreatedDate,
            UpdatedDate = banners.UpdatedDate,
            DeletedDate = banners.DeletedDate,
            IsDeleted = banners.IsDeleted,
        };
    }
}
