
using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandByIdQuery : BaseEntity
{
    public GetBrandByIdQuery(int id)
    {
        Id = id;
    }
}
