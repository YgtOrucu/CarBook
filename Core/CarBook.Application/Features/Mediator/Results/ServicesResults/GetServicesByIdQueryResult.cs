using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.ServicesResults;

public class GetServicesByIdQueryResult : AuditableDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
}
