using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Results.CategoryResult;
public class GetCategoryQueryResult : BaseEntity
{
    public string? Name { get; set; }
}
