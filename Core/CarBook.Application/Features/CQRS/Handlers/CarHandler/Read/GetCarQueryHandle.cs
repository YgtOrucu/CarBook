using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarQueryHandle(IRepository<Car> repository)
{
    public async Task<List<GetCarQueryResult>> Handle()
    {
        var values = await repository.GetAllAsync();

        return values.Select(x => new GetCarQueryResult
        {
            BrandId = x.BrandId,
            CoverImageUrl = x.CoverImageUrl,
            Id = x.Id,
            Model = x.Model,
            CarKM = x.CarKM,
            Fuel = x.Fuel,
            LuggageCount = x.LuggageCount,
            SeatCount = x.SeatCount,
            Transmission = x.Transmission
        }).ToList();
    }
}
