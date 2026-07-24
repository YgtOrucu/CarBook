using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;

public class CreateContactCommandHandle(IRepository<Contact> repository,IUnitOfWork unitOfWork)
{
    public async Task Handle(CreateContactCommand command)
    {
        await repository.CreateAsync(new Contact
        {
            Name = command.Name,
            Email = command.Email,
            Message = command.Message,
            SendDate = DateTime.Now,
            Subject = command.Subject,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
