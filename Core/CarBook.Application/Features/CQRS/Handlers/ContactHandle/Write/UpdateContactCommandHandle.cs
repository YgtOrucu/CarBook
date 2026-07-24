using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandle.Write;

public class UpdateContactCommandHandle(IRepository<Contact> repository, IUnitOfWork unitOfWork)
{
    public async Task Handle(UpdateContactCommand command)
    {
        repository.Update(new Contact
        {
            Id = command.Id,
            Name = command.Name,
            Email = command.Email,
            Message = command.Message,
            SendDate = DateTime.Now,
            Subject = command.Subject,
        });

        await unitOfWork.SaveChangeAsync();
    }
}
