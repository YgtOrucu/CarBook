using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommand;

public class RemoveAboutCommand : AuditableEntity
{
    public RemoveAboutCommand(int id)
    {
        Id = id;
    }
}
