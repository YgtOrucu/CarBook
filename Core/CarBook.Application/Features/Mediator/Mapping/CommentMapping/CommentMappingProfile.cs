using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Mapping.CommentMapping;

public class CommentMappingProfile : Profile
{
    public CommentMappingProfile()
    {
        CreateMap<CreateCommentCommand, Comment>();
        CreateMap<UpdateCommentCommand, Comment>();
        CreateMap<UpdateCommentForUserCommand, Comment>();
        CreateMap<Comment, GetCommentQueryResult>();
        CreateMap<Comment, GetCommentByIdQueryResult>();
        CreateMap<Comment, GetCommentByBlogIdQueryResult>();
        CreateMap<Comment, GetLoginUsersCommentQueryResult>().ForMember(opt => opt.BlogTitle, desc => desc.MapFrom(src => src.Blog.Title));

        CreateMap<Comment, GetCommentWithBlogTitleQueryResult>()
            .ForMember(opt => opt.BlogTitle, desc => desc.MapFrom(src => src.Blog.Title));
    }
}
