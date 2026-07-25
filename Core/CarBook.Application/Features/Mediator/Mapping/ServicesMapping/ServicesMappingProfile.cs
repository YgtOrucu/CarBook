using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ServicesCommands;
using CarBook.Application.Features.Mediator.Results.ServicesResults;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.ServicesMapping;

public class ServicesMappingProfile : Profile
{
    public ServicesMappingProfile()
    {
        CreateMap<CreateServicesCommand, Service>();
        CreateMap<UpdateServicesCommand, Service>();
        CreateMap<Service, GetServicesQueryResult>();
        CreateMap<Service, GetServicesByIdQueryResult>();
    }
}
