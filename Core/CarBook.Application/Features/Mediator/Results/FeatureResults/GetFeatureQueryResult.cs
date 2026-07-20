using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.Mediator.Results.FeatureResults;
public class GetFeatureQueryResult : BaseEntity
{
    public string? Name { get; set; }
}
