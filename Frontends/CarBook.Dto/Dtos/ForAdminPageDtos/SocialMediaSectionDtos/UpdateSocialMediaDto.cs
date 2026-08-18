using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.SocialMediaSectionDtos;
public class UpdateSocialMediaDto : AuditableDto
{
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string? Url { get; set; }
}
