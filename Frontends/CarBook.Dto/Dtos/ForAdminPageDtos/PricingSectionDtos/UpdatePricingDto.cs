using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.PricingSectionDtos;

public class UpdatePricingDto : AuditableDto
{
    public string? Name { get; set; }
}
