using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.BannerSectionDtos;

public class UpdateBannerDto : BaseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? VideoUrl { get; set; }
}
