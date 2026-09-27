namespace CarBook.Dto.Dtos.ForUsersPageDtos.CommentSectionDto;

public class GetLoginUsersComments
{
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string MessageBody { get; set; }
    public string BlogTitle { get; set; }
    public bool IsDeleted { get; set; }
}
