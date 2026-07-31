using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TagCommands;
using CarBook.Application.Features.Mediator.Results.TagResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.TagMapping;

public class TagMappingProfile : Profile
{
    public TagMappingProfile()
    {
        CreateMap<CreateTagCommand, Tag>();
        CreateMap<UpdateTagCommand, Tag>();
        CreateMap<RemoveTagCommand, Tag>();

        CreateMap<Tag,GetTagQueryResult>();
        CreateMap<Tag, GetTagByIdQueryResult>();
    }
}
