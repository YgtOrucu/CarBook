namespace CarBook.Application.Features.CQRS.Results.CarResult;
public class GetCarLastest5ForPresantationPageResult
{
    public string? BrandName { get; set; }
    public string? Model { get; set; }
    public string? CoverImageUrl { get; set; }
    public int? CarDetailsId { get; set; }
    public decimal CarAmount { get; set; }
    public string CarPricingName { get; set; }
}
