using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace ContactBook.Application.Features.CQRS.Handlers.ContactHandle.Read;

public class GetContactByIdQueryHandle(IRepository<Contact> repository)
{
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
    {
        var values = await repository.GetByIdAsync(getContactByIdQuery.id);

        return new GetContactByIdQueryResult
        {
            Id = values.Id,
            Name = values.Name,
            Email = values.Email,
            Message = values.Message,
            Subject = values.Subject,
            SendDate = values.SendDate
        };
    }
}
