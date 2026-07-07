
using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Commands.BrandCommand;

public class CreateBrandCommand : AuditableEntity
{
    public string? Name { get; set; }
}
