using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write;

public class UpdateCommentCommandHandle(IRepository<Comment> repository,IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCommentCommand, object>
{
    public async Task<object> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);

        mapper.Map(request, values);
        repository.Update(values);
        await unitOfWork.SaveChangeAsync();
        return new
        {
            success = true,
            messages = "The update process was succesful.",
            data = values
        };
    }
}
