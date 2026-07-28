using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.FooterAddressMapping;

public class FooterAddressMappingProfile : Profile
{
    public FooterAddressMappingProfile()
    {
        CreateMap<CreateFooterAddressCommand, FooterAddress>();
        CreateMap<UpdateFooterAddressCommand, FooterAddress>();
        CreateMap<FooterAddress, GetFooterAddressQueryResult>();
        CreateMap<FooterAddress, GetFooterAddressByIdQueryResult>();
        CreateMap<FooterAddress, GetFooterAddressForPresantationPageQueryResult>();
    }
}
