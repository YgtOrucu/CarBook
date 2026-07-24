namespace CarBook.Application.Features.Mediator.Results.PricingResult;

public record GetPricingByIdQueryResult(int Id, string Name, DateTime CreatedDate, DateTime UpdatedDate, DateTime DeletedDate);

