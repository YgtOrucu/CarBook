using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.ServiceSectionDtos;

public class ResultServiceDto : AuditableDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? IconUrl { get; set; }
}
