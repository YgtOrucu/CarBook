using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarBook.Infrastructure.Repositories;

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

    public async Task<AnswerAIQueryResult> AnswerOpenAIForCreateBlogAsync(string CategoryName)
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
                    content = "Sen otomotiv, araç kiralama ve seyahat sektöründe uzmanlaşmış profesyonel bir blog yazarısın. " +
                              "Sana verilen kategori adına uygun, ilgi çekici bir blog başlığı (title) ve detaylı, özgün bir blog açıklaması (description) oluşturmalısın. " +
                              "Çıktıyı YALNIZCA aşağıdaki JSON formatında ver:\n{\n  \"title\": \"...\",\n  \"description\": \"...\"\n}"
                },
                new
                {
                    role = "user",
                    content = $"Lütfen '{CategoryName}' kategorisi ile doğrudan ilgili akıcı, SEO uyumlu ve ilgi çekici bir blog yazısı başlığı ve 2-3 paragraflık detaylı bir içerik açıklaması üret."
                }
            },
            response_format = new { type = "json_object" },
            temperature = 0.7
        };

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _APIKEY);

        var response = await client.PostAsJsonAsync("chat/completions", requestBody);

        if (response.IsSuccessStatusCode)
        {
            var openAiResponse = await response.Content.ReadFromJsonAsync<OpenAiResponseDto>();
            var jsonContent = openAiResponse?.Choice?.FirstOrDefault()?.Message?.Content;

            if (!string.IsNullOrEmpty(jsonContent))
            {
                var result = JsonSerializer.Deserialize<AnswerAIQueryResult>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result ?? new AnswerAIQueryResult();
            }
        }
        return new AnswerAIQueryResult();
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
