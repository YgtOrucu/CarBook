using AutoMapper;
using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write;

public class UpdateCommentForUserCommandHandle(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCommentForUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateCommentForUserCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, values);
        repository.Update(values);
        var result = await unitOfWork.SaveChangeAsync();

        return BaseResult<object>.Success(result, "The update process was succesful.");
    }
}
