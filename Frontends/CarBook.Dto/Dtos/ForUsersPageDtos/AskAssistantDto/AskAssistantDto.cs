
namespace CarBook.Dto.Dtos.ForUsersPageDtos.AskAssistantDto;

public class AskAssistantDto
{
    public string Message { get; set; }
    public List<ChatMessageDto> History { get; set; } = new();
}

public class ChatMessageDto
{
    public string Role { get; set; } 
    public string Content { get; set; }
}

public class AssistantAnswerDto
{
    public string Answer { get; set; }
}
