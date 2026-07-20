using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.Mediator.Results.FooterAddressResult;
public class GetFooterAddressQueryResult : BaseEntity
{
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
