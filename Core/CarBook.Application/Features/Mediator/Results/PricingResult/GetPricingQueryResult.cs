namespace CarBook.Application.Features.Mediator.Results.PricingResult;

public record GetPricingQueryResult(int Id, string Name, DateTime CreatedDate, DateTime UpdatedDate, DateTime DeletedDate, bool IsDeleted);