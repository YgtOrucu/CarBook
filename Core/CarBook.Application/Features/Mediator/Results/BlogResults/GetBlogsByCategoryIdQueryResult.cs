using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.BlogResults;
public class GetBlogsByCategoryIdQueryResult : AuditableDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public string? AuthorName { get; set; }
    public string? CategoryName { get; set; }
    public string Description { get; set; }
}
