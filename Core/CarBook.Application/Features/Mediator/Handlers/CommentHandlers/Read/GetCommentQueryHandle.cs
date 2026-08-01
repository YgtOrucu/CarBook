using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetCommentQueryHandle(IRepository<Comment> repository, IMapper mapper)
    : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
{
    public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<GetCommentQueryResult>>(await repository.GetAllAsync());
    }
}
