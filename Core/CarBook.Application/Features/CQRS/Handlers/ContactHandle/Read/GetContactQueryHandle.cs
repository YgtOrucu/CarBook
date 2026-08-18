using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace ContactBook.Application.Features.CQRS.Handlers.ContactHandle.Read;

public class GetContactQueryHandle(IRepository<Contact> repository)
{
    public async Task<List<GetContactQueryResult>> Handle()
    {
        var values = await repository.GetAllAsync();

        return values.Select(x => new GetContactQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Message = x.Message,
            Subject = x.Subject,
            SendDate = x.SendDate,
            IsStatus = x.IsStatus,
        }).ToList();
    }
}
