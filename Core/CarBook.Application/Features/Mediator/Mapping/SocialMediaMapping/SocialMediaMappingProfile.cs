using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.SocialMediaMapping;
public class SocialMediaMappingProfile:Profile
{
    public SocialMediaMappingProfile()
    {
        CreateMap<CreateSocialMediaCommand, SocialMedia>();
        CreateMap<UpdateSocialMediaCommand, SocialMedia>();
        CreateMap<SocialMedia, GetSocialMediaQueryResult>();
        CreateMap<SocialMedia, GetSocialMediaByIdQueryResult>();
    }
}
