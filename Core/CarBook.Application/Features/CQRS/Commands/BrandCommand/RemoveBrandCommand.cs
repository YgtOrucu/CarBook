using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommand;

public class RemoveBrandCommand : BaseEntity
{
    public RemoveBrandCommand(int id)
    {
        Id = id;
    }
}
