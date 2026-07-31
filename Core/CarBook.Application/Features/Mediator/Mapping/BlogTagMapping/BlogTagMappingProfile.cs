using AutoMapper;
using CarBook.Application.Features.Mediator.Results.BlogTagResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.BlogTagMapping;

public class BlogTagMappingProfile : Profile
{
	public BlogTagMappingProfile()
	{
		CreateMap<Tag, GetTag4PieceForBlogDetailPageQueryResult>();
		CreateMap<Tag, GetTagAllForBlogDetailPageQueryResult>();
	}
}
