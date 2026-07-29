using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.BlogResults;

public class GetBlogQueryResult : AuditableDto
{
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public int? AuthorId { get; set; }
    public string AuthorName { get; set; }
    public int? CategoryId { get; set; }
    public string CategoryName { get; set; }
}
