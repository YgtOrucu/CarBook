using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;

public class CreateBrandCommandHandle
{
    private readonly IRepository<Brand> _brandRepository;

    public CreateBrandCommandHandle(IRepository<Brand> brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task Handle(CreateBrandCommand command)
    {
        await _brandRepository.CreateAsync(new Brand
        {
            Name = command.Name,
        });
    }
}
