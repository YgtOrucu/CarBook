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
            CarDetailsId = x.CarDetailsId,
            CoverImageUrl = x.CoverImageUrl,
            Id = x.Id,
            Model = x.Model,
            BigImageUrl = x.CarDetails.BigImageUrl,
            CarKM = x.CarDetails.CarKM,
            Fuel = x.CarDetails.Fuel,
            LuggageCount = x.CarDetails.LuggageCount,
            SeatCount = x.CarDetails.SeatCount,
            Transmission = x.CarDetails.Transmission
        }).ToList();
    }
}
