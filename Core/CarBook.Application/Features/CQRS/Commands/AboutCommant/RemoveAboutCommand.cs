using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommant;

public class RemoveAboutCommand : AuditableEntity
{
    public RemoveAboutCommand(int id)
    {
        Id = id;
    }
}
