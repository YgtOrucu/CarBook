using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace CarBook.Persistence.Repositories;

public class OpenAIRepository(IConfiguration configuration, IHttpClientFactory httpClientFactory) : IOpenAIRepository
{
    private string _APIKEY => configuration["ApiKey"]!;
    public async Task<AnswerOpenAI> AnswerOpenAIAsync(string Message, string Name)
    {
        var client = httpClientFactory.CreateClient("OpenAIAddress");

        var requestBody = new
        {
            model = "gpt-4o-mini",
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = @"Sen 'CarBook' adlı araç kiralama şirketinin son derece profesyonel, nazik ve çözüm odaklı Müşteri İlişkileri Temsilcisisin.
                               Görevin: Müşteriden gelen ileşitim mesajını dikkatlice analiz edip, müşterinin kafasında hiçbir soru işareti bırakmayacak, kurumsal, anlaşılır ve profesyonel bir yanıt taslağı hazırlamaktır.
                               
                               Yanıt verirken şu kurallara kesinlikle uy:
                               1. Yanıta mutlaka müşterinin ismi ile saygılı bir hitapla başla (Örn: 'Sayın [Müşteri Adı],').
                               2. Müşterinin ilettiği konu ve mesaj içeriğine doğrudan değinerek mesajının alındığını belirt.
                               3. Açıklayıcı, net ve güven veren bir dil kullan. Müşteri bir sorun bildirdiyse çözüm sürecini anlat; bilgi istediyse net bilgi ver.
                               4.Noktalama işaretlerine,yazım kurallarına,paragraf başlarına ve sonlarına dikkat et.
                               5. Yanıtın sonuna şirket adı olarak 'CarBook Müşteri Destek Ekibi' imzasını ekle.
                               6. Üretilen mesaj müşteriye e-posta ile gönderilecek bu yüzden ekstra tırnak işaretleri veya açıklama metinleri ekleme."
                },
                new
                {
                    role = "user",
                    content = $@"Müşteri Adı: {Name}
                                 Müşterinin Mesajı: {Message}
                                 
                                 Lütfen yukarıdaki mesajı inceleyerek müşteriye gönderilecek profesyonel yanıtı oluştur."
                }
            },
            temperature = 0.5
        };


        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _APIKEY);

        var response = await client.PostAsJsonAsync("chat/completions", requestBody);

        if (response.IsSuccessStatusCode)
        {
            var value = await response.Content.ReadFromJsonAsync<OpenAiResponseDto>();
            return new AnswerOpenAI { Answer = value.Choice[0].Message.Content };
        }
        else
        {
            return new AnswerOpenAI { Answer = $"Mesaj oluşturuluklen bir hata ile karşılaşıldı : {response.StatusCode}" };
        }
    }

    public class OpenAiResponseDto
    {
        [JsonPropertyName("choices")]
        public List<Choice>? Choice { get; set; }
    }
    public class Choice
    {
        [JsonPropertyName("message")]
        public Message? Message { get; set; }
    }
    public class Message
    {
        [JsonPropertyName("content")]
        public string? Content { get; set; }
    }
}
