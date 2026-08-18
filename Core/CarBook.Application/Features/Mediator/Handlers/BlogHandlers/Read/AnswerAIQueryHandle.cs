using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class AnswerAIQueryHandle(IOpenAIRepository repository)
    : IRequestHandler<AnswerAIQuery, AnswerAIQueryResult>
{
    public async Task<AnswerAIQueryResult> Handle(AnswerAIQuery request, CancellationToken cancellationToken)
    {
        var value = await repository.AnswerOpenAIForCreateBlogAsync(request.CategoryName);
        return value;

    }
}
