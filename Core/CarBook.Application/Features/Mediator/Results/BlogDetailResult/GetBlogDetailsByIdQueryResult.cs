using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.BlogDetailResult;

public class GetBlogDetailsByIdQueryResult : BaseDto
{
    public string MainTitle { get; set; }
    public string MainDescription { get; set; }
    public string SecondTitle { get; set; }
    public string SecondDescription { get; set; }
}
