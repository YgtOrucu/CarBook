using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommant;

public class RemoveAboutCommant : AuditableEntity
{
    public RemoveAboutCommant(int id)
    {
        Id = id;
    }
}
