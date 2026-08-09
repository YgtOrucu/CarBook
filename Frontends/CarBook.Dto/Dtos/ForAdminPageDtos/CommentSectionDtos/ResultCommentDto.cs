using CarBook.Dto.Dtos.Base;

namespace CarBook.Dto.Dtos.ForAdminPageDtos.CommentSectionDtos;
public class ResultCommentDto : AuditableDto
{
    public string? NameSurname { get; set; }
    public string? ImageUrl { get; set; }
    public string? MessageBody { get; set; }
    public string? BlogTitle { get; set; }
}
