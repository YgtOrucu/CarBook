using AutoMapper;
using CarBook.Application.Features.CQRS.Results.CarResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Mapping.CarMapping;

public class CarMappingProfile : Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, GetCarForPresantationPageResult>()
            .ForMember(opt => opt.CarPricingName, desc => desc.MapFrom(src => src.CarPricings.FirstOrDefault(x => x.PricingId == 5).Pricing.Name))
            .ForMember(opt => opt.CarAmount, desc => desc.MapFrom(src => src.CarPricings.FirstOrDefault(x => x.PricingId == 5).Amount));
    }
}
