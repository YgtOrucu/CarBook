using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetCommentByBlogIdQueryHandler(IRepository<Comment> repository)
    : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
{
    public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
    {
        var values = repository.GetByQuery()
            .Where(x => x.BlogId == request.BlogId)
            .Select(g => new GetCommentByBlogIdQueryResult
            {
                NameSurname = g.NameSurname,
                MessageBody = g.MessageBody,
                CreatedDate = g.CreatedDate
            })
            .ToList();

        return values;
    }
}