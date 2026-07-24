using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.LocationMapping;

public class LocationMappingProfile:Profile
{
    public LocationMappingProfile()
    {
        CreateMap<CreateLocationCommand, Location>();
        CreateMap<UpdateLocationCommand, Location>();

        CreateMap<Location, GetLocationQueryResult>();
        CreateMap<Location, GetLocationByIdQueryResult>();
    }
}
