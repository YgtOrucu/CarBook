using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetCommentWithBlogTitleQueryHandle(IRepository<Comment> repository, IMapper mapper)
    : IRequestHandler<GetCommentWithBlogTitleQuery, List<GetCommentWithBlogTitleQueryResult>>
{
    public async Task<List<GetCommentWithBlogTitleQueryResult>> Handle(GetCommentWithBlogTitleQuery request, CancellationToken cancellationToken)
    {
        var value = repository.GetByQuery().ProjectTo<GetCommentWithBlogTitleQueryResult>(mapper.ConfigurationProvider).ToList();
        return value;  
    }
}
