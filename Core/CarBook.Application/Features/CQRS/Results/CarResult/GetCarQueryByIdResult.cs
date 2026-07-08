using CarBook.Domain.Entities.Comman;

namespace CarBook.Application.Features.CQRS.Results.CarResult;
public class GetCarQueryByIdResult : BaseEntity
{
    public int? BrandId { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int? CarDetailsId { get; set; }
}
