using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AskAssistantHandler;

public class AskAssistantCommandHandler(IOpenAIRepository repository)
    : IRequestHandler<AskAssistantCommand, BaseResult<AssistantAnswerDto>>
{

    public async Task<BaseResult<AssistantAnswerDto>> Handle(AskAssistantCommand request, CancellationToken cancellationToken)
    {
        var answer = await repository.GetAnswerAsync(request.Message, request.History);
        return BaseResult<AssistantAnswerDto>.Success(new AssistantAnswerDto { Answer = answer });
    }
}
