using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandles.Read;
public class GetCategoryByIdCommandHandle(IRepository<Category> repository)
{
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var values = await repository.GetByIdAsync(query.id);

        return new GetCategoryByIdQueryResult
        {
            Id = values.Id,
            Name = values.Name
        };
    }
}
