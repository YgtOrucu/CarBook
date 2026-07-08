using CarBook.Application.Features.CQRS.Results.CategoryResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Read;

public class GetCategoryCommandHandle(IRepository<Category> repository)
{
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await repository.GetAllAsync();

        return values.Select(x => new GetCategoryQueryResult
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}
