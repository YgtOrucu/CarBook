using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetLoginUsersCommentQueryHandle(IRepository<Comment> repository, IMapper mapper)
    : IRequestHandler<GetLoginUsersCommentQuery, BaseResult<List<GetLoginUsersCommentQueryResult>>>
{
    public async Task<BaseResult<List<GetLoginUsersCommentQueryResult>>> Handle(GetLoginUsersCommentQuery request, CancellationToken cancellationToken)
    {
        var values = repository.GetByQuery().Where(x => x.Email == request.userEmail && x.IsDeleted == false).ProjectTo<GetLoginUsersCommentQueryResult>(mapper.ConfigurationProvider).ToList();
        return BaseResult<List<GetLoginUsersCommentQueryResult>>.Success(values);
    }
}
