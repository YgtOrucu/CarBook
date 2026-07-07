using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Results.BrandResult;

public class GetBrandQueryResult : BaseEntity
{
    public string? Name { get; set; }
}

