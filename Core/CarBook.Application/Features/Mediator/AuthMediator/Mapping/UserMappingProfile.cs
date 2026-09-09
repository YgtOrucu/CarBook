using AutoMapper;
using CarBook.Application.Features.Mediator.AuthMediator.Commands;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.AuthMediator.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<CreateRegisterCommand, AppUser>();
    }
}
