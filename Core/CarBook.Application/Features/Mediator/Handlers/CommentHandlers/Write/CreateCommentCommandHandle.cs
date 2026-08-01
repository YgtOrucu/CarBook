using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write;

public class CreateCommentCommandHandle(IRepository<Comment> repository, IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCommentCommand, object>
{
    public async Task<object> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var values = mapper.Map<Comment>(request);
        await repository.CreateAsync(values);
        await unitOfWork.SaveChangeAsync();
        return new
        {
            success = true,
            messages = "The addition was succesful",
            data = values
        };
    }
}
