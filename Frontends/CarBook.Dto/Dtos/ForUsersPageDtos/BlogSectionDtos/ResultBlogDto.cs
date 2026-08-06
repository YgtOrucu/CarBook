namespace CarBook.Dto.Dtos.ForUsersPageDtos.BlogSectionDtos;

public class ResultBlogDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string AuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
}
