using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.BlogMapping;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<Blog, GetBlogQueryResult>();
        CreateMap<Blog, GetBlogByIdQueryResult>();
        CreateMap<Blog, GetBlogLastest3ForPresantationPageQueryResult>();
        CreateMap<Blog, GetBlogLastest5ForPresantationPageQueryResult>();
        CreateMap<CreateBlogCommand, Blog>();
        CreateMap<UpdateBlogCommand, Blog>();
        CreateMap<RemoveBlogCommand, Blog>();

        CreateMap<Blog, GetBlogsByCategoryIdQueryResult>();
    }
}
