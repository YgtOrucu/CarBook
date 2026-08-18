using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandle.Read;

public class AnswerOpenAIQueryHandle(IOpenAIRepository repository)
    : IRequestHandler<AnswerOpenAIQuery, AnswerOpenAI>
{
    public async Task<AnswerOpenAI> Handle(AnswerOpenAIQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            throw new Exception("Occurred an error.");

        var answerOpenAI =  await repository.AnswerOpenAIAsync(request.Message, request.Name);
        return answerOpenAI;
    }
}
