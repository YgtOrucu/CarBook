using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetCommentByIdQueryHandle(IRepository<Comment> repository, IMapper mapper)
    : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
{
    public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetCommentByIdQueryResult>(await repository.GetByIdAsync(request.Id));
    }
}
