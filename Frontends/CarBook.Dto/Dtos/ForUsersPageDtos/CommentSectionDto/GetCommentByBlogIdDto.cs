namespace CarBook.Dto.Dtos.ForUsersPageDtos.CommentSectionDto;

public class GetCommentByBlogIdDto
{
    public string NameSurname { get; set; }
    public string MessageBody { get; set; }
    public DateTime CreatedDate { get; set; }

    public string Initials
    {
        get
        {
            if (string.IsNullOrWhiteSpace(NameSurname))
                return string.Empty;

            var parts = NameSurname.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                return parts[0][0].ToString().ToUpper();
            }

            return $"{parts[0][0]}{parts[^1][0]}".ToUpper();
        }
    }
}