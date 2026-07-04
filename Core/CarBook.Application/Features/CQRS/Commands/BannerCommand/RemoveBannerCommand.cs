using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.BannerCommand;

public class RemoveBannerCommand : BaseEntity
{
    public RemoveBannerCommand(int id)
    {
        Id = id;
    }
}
