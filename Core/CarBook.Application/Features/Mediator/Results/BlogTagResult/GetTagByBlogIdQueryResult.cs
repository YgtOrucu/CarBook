using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.BlogTagResult;

public class GetTagByBlogIdQueryResult : BaseDto
{
    public string TagName { get; set; }
}
