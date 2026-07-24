using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
public class GetBannerByIdQueryHandle
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandle(IRepository<Banner> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery query)
    {
        var banner = await _repository.GetByIdAsync(query.Id);
        var result = new List<GetBannerByIdQueryResult>();
        if (banner != null)
        {
            result.Add(new GetBannerByIdQueryResult
            {
                Id = banner.Id,
                Title = banner.Title,
                Description = banner.Description,
                VideoUrl = banner.VideoUrl,
            });
        }
        return result;
    }
}
