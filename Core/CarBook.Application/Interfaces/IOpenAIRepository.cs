using CarBook.Application.Features.CQRS.Results.ContactResult;

namespace CarBook.Application.Interfaces;
public interface IOpenAIRepository
{
    Task<AnswerOpenAI> AnswerOpenAIAsync(string Message, string Name);
}
