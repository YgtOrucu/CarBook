using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write;

public class RemoveBlogCommandHandle(IRepository<Blog> repository, IUnitOfWork unitOfWork)
    : IRequestHandler<RemoveBlogCommand, object>
{
    public async Task<object> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
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
