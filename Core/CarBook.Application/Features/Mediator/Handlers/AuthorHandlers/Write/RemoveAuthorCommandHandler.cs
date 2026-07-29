using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write;

public class RemoveAuthorCommandHandler(IRepository<Author> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveAuthorCommand, object>
{
    public async Task<object> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
    {
        var values = await repository.GetByIdAsync(request.Id);
        repository.Delete(values);
        var result = await unitOfWork.SaveChangeAsync();
        return new
        {
            success = result,
            Message = "The deletion was successful",
            value = values
        };
    }
}
