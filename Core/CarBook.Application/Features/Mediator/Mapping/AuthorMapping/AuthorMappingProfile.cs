using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.AuthorMapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<UpdateAuthorCommand, Author>();
        CreateMap<RemoveAuthorCommand, Author>();
        CreateMap<Author, GetAuthorQueryResult>();
        CreateMap<Author, GetAuthorByIdQueryResult>();
        CreateMap<Author, GetAuthorByBlogIdForBlogDetailPageQueryResult>();
    }
}
