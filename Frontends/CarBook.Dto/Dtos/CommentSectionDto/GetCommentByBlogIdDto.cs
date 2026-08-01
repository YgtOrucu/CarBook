namespace CarBook.Dto.Dtos.CommentSectionDto;
public class GetCommentByBlogIdDto
{
    public string NameSurname { get; set; }
    public string? ImageUrl { get; set; }
    public string MessageBody { get; set; }
    public DateTime CreatedDate { get; set; }
}
