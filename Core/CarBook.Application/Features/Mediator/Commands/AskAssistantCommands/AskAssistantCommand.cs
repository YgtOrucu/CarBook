using CarBook.Application.Base;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;

public class AskAssistantCommand : IRequest<BaseResult<AssistantAnswerDto>>
{
    public string Message { get; set; } = null!;
    public List<ChatMessageDto> History { get; set; } = new();
}

public class ChatMessageDto
{
    public string Role { get; set; } = null!; 
    public string Content { get; set; } = null!;
}

public class AssistantAnswerDto
{
    public string Answer { get; set; } = null!;
}