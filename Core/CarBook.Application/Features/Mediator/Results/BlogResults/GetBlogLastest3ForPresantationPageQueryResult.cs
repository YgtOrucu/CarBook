namespace CarBook.Application.Features.Mediator.Results.BlogResults;

public class GetBlogLastest3ForPresantationPageQueryResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string AuthorName { get; set; }
    public DateTime CreatedDate { get; set; }
}
