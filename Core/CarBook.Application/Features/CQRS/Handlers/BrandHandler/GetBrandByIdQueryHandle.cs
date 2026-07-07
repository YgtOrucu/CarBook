using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;

public class GetBrandByIdQueryHandle
{
    private readonly IRepository<Brand> _brandRepository;

    public GetBrandByIdQueryHandle(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<GetBrandByIdQueryResult> Handle (GetBrandByIdQuery query)
    {
        var values = await _brandRepository.GetByIdAsync(query.Id);

        return new GetBrandByIdQueryResult
        {
            Id = values.Id,
            Name = values.Name
        };
    }
}
