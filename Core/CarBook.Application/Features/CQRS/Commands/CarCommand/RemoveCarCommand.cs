using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.CarCommand;

public class RemoveCarCommand : BaseEntity
{
    public RemoveCarCommand(int id)
    {
        Id = id;
    }
}
