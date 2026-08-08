using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.CategorySectionDtos;

public class ResultBlogsByCategoryDto : AuditableDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public int? AuthorName { get; set; }
    public string Description { get; set; }
}
