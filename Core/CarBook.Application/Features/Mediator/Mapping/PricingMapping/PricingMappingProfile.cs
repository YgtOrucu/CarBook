using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.PricingMapping;
public class PricingMappingProfile:Profile
{
    public PricingMappingProfile()
    {
        CreateMap<CreatePricingCommand, Pricing>();
        CreateMap<UpdatePricingCommand, Pricing>();
        CreateMap<Pricing, GetPricingQueryResult>();
        CreateMap<Pricing, GetPricingByIdQueryResult>();
    }
}
