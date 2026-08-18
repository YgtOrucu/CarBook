namespace CarBook.Dto.Dtos.ForAdminPageDtos.BlogSectionDtos;

public class CreateBlogDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string Description { get; set; }
    public int? AuthorId { get; set; }
    public int? CategoryId { get; set; }
}
