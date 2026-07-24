using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;

public class RemoveContactCommandHandle(IRepository<Contact> repository,IUnitOfWork unitOfWork)
{
    public async Task Handle(RemoveContactCommand command)
    {
        var entity = await repository.GetByIdAsync(command.id);
        if (entity != null)
        {
            repository.Delete(entity);
        }
        await unitOfWork.SaveChangeAsync();
    }
}
