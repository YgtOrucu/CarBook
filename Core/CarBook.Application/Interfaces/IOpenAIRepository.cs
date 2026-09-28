using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;
using CarBook.Application.Features.Mediator.Results.BlogResults;

namespace CarBook.Application.Interfaces;
public interface IOpenAIRepository
{
    Task<AnswerOpenAI> AnswerOpenAIAsync(string Message, string Name);
    Task<AnswerAIQueryResult> AnswerOpenAIForCreateBlogAsync(string CategoryName);
    Task<string> GetAnswerAsync(string message, List<ChatMessageDto> history, string? systemPrompt = null);
    Task<string> GenerateReservationReplyAsync(string userPrompt, string? systemPrompt = null);
}
