using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.TestimonialSectionDtos;

public class UpdateTestimonialDto : AuditableDto
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ImageUrl { get; set; }
}
