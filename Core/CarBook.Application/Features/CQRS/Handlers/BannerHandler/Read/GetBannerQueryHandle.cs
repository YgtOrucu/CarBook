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
    public async Task<List<GetBannerQueryResult>> Handle()
    {
        var banners = await _repository.GetAllAsync();
        return banners.Select(b => new GetBannerQueryResult
        {
            Id = b.Id,
            Title = b.Title,
            Description = b.Description,
            VideoUrl = b.VideoUrl,
        }).ToList();
    }
}
