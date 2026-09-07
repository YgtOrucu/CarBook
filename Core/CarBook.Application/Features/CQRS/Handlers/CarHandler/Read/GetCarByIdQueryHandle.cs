using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler.Read;

public class GetCarByIdQueryHandle(IRepository<Car> repository)
{
    public async Task<GetCarQueryByIdResult> Handle(GetCarByIdQuery getCarByIdQuery)
    {
        var values = await repository.GetByIdAsync(getCarByIdQuery.id);

        return new GetCarQueryByIdResult
        {
            BrandId = values.BrandId,
            CoverImageUrl = values.CoverImageUrl,
            Id = values.Id,
            Model = values.Model,
            BigImageUrl = values.BigImageUrl,
            CarKM = values.CarKM,
            Fuel = values.Fuel,
            LuggageCount = values.LuggageCount,
            SeatCount = values.SeatCount,
            Transmission = values.Transmission
        };
    }
}
