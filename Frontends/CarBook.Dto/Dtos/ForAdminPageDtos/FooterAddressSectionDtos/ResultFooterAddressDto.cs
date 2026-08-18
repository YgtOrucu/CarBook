using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.FooterAddressSectionDtos;

public class ResultFooterAddressDto : BaseDto
{
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
