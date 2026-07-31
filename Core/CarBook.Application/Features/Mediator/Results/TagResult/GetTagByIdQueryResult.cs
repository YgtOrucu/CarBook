using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.TagResult;

public class GetTagByIdQueryResult : BaseDto
{
    public string TagName { get; set; }
}
