using CarBook.Application.Base;

namespace CarBook.Application.Features.Mediator.Results.CommentResult;
public class GetCommentWithBlogTitleQueryResult : AuditableDto
{
    public string NameSurname { get; set; }
    public string? ImageUrl { get; set; }
    public string MessageBody { get; set; }
    public string BlogTitle { get; set; }
}
