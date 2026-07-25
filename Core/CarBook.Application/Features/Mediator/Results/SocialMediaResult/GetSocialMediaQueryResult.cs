using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.SocialMediaResult;

public class GetSocialMediaQueryResult : AuditableDto
{
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string? Url { get; set; }
}
