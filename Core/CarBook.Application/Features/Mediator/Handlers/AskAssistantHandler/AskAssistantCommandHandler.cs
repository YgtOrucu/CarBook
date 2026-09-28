using CarBook.Application.Base;
using CarBook.Application.Features.Mediator.Commands.AskAssistantCommands;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AskAssistantHandler;

public class AskAssistantCommandHandler(IOpenAIRepository repository)
    : IRequestHandler<AskAssistantCommand, BaseResult<AssistantAnswerDto>>
{
    private const string systemPrompt =
    "Sen CarBook araç kiralama platformunun yapay zeka danışmanısın. " +
    "Kullanıcılara rezervasyon, araç seçimi, fiyatlandırma ve kiralama süreçleri hakkında " +
    "kısa, net, samimi ve Türkçe yanıtlar ver. " +
    "Eğer kullanıcı selamlaşma (merhaba, naber, nasılsın vb.) veya genel bir sohbet başlatırsa; " +
    "sıcak bir şekilde karşılık ver, CarBook ailesine hoş geldin de ve hemen ardından " +
    "\"Sana nasıl bir araç bulmamı istersin?\" veya \"Tatil ya da iş gezisi için mi araç arıyorsun?\" " +
    "şeklinde konuyu nazikçe araç kiralama süreçlerine bağla. " +
    "CarBook platformu dışındaki konularda (teknoloji, genel kültür vb.) çok kısa bir cümleyle " +
    "nazikçe kibarca reddedip tekrar araç kiralama konularına yönlendir.";

    public async Task<BaseResult<AssistantAnswerDto>> Handle(AskAssistantCommand request, CancellationToken cancellationToken)
    {
        var answer = await repository.GetAnswerAsync(request.Message, request.History, systemPrompt);
        return BaseResult<AssistantAnswerDto>.Success(new AssistantAnswerDto { Answer = answer });
    }
}
