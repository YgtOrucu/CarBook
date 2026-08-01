namespace CarBook.Application.Features.Mediator.Results.CommentResult;

public class GetCommentByBlogIdQueryResult
{
    public string NameSurname { get; set; }
    public string? ImageUrl { get; set; }
    public string MessageBody { get; set; }
    public DateTime CreatedDate { get; set; }
}
