using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarWithBrandQueryHandle(ICarRepository repository)
{

    public async Task<List<GetCarWithBrandQueryResult>> Handle()
    {
        var values = await repository.GetCarsWithBrandAsync();

        return values.Select(x => new GetCarWithBrandQueryResult
        {
            BrandId = x.BrandId,
            BrandName = x.Brand?.Name,
            CoverImageUrl = x.CoverImageUrl,
            Id = x.Id,
            Model = x.Model,
            BigImageUrl = x.BigImageUrl,
            CarKM = x.CarKM,
            Fuel = x.Fuel,
            LuggageCount = x.LuggageCount,
            SeatCount = x.SeatCount,
            Transmission = x.Transmission,
            IsDeleted = x.IsDeleted,       
        }).ToList();
    }
}
