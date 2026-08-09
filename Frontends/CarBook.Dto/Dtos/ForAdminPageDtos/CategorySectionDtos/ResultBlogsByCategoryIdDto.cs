using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.CategorySectionDtos;

public class ResultBlogsByCategoryIdDto : AuditableDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string? AuthorName { get; set; }
    public string? CategoryName { get; set; }
    public string Description { get; set; }
}
