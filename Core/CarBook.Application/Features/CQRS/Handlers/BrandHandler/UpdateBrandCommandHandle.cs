using CarBook.Application.Features.CQRS.Commands.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandler;

public class UpdateBrandCommandHandle
{
    private readonly IRepository<Brand> _repository;

    public UpdateBrandCommandHandle(IRepository<Brand> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateBrandCommand commant)
    {
        _repository.Update(new Brand
        {
            Id = commant.Id,
            Name = commant.Name,
        });
    }
}
