using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write;

public class RemoveCommentCommandHandle(IRepository<Comment> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveCommentCommand, object>
{
    public async Task<object> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var deletedvalue = await repository.GetByIdAsync(request.Id);
        if (deletedvalue == null)
            throw new Exception("Deleted Value could not found");

        repository.Delete(deletedvalue);
        var result = await unitOfWork.SaveChangeAsync();
        return new
        {
            success = result,
            Message = "The deletion was successful",
            value = deletedvalue
        };
    }
}
