using AutoMapper;
using CarBook.Application.Features.Mediator.Results.BlogDetailResult;
using CarBook.Domain.Entities;
namespace CarBook.Application.Features.Mediator.Mapping.BlogDetailMapping;

public class BlogDetailMappingProfile : Profile
{
    public BlogDetailMappingProfile()
    {
        CreateMap<BlogDetail, GetBlogDetailsByIdQueryResult>();
    }
}
