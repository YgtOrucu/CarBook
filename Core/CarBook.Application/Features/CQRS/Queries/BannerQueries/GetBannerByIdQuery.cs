using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Queries.BannerQueries;

public class GetBannerByIdQuery : BaseEntity
{
    public GetBannerByIdQuery(int id)
    {
        Id = id;
    }
}
