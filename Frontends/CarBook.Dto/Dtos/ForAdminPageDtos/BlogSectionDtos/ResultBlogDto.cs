namespace CarBook.Dto.Dtos.ForAdminPageDtos.BlogSectionDtos;

public class ResultBlogDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    //public int? AuthorId { get; set; }
    public string AuthorName { get; set; }
    //public int? CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}
