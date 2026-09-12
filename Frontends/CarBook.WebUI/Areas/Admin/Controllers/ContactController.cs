using CarBook.Dto.Dtos.ForAdminPageDtos.ContactSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController(IHttpClientFactory httpClientFactory) : AdminBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"Contact");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultContactDto>>();
                return View(value);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetDetailContact(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateContactDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateAIMessage([FromBody] GenerateAiRequestContactDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"contact/GetOpenAIAnswer?Message={dto.Message}&Name={dto.Name}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<AnswerOpenAI>();
                string aiMessage = value?.Answer ?? "Yanıt üretilemedi.";

                return Json(new { success = true, reply = aiMessage });
            }
            return Json(new { success = false, message = "API'den yanıt alınamadı." });
        }

        [HttpPost]
        public async Task<IActionResult> SendReply(SendMailDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var getResponse = await client.PostAsJsonAsync("contact/SendMessage", dto);

            if (getResponse.IsSuccessStatusCode)
            {
                var result = await getResponse.Content.ReadFromJsonAsync<SendMessageResponseDto>();
                TempData["SuccessMessage"] = result?.Message ?? "Mail başarıyla gönderildi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Mail gönderilirken bir hata oluştu.";
            return RedirectToAction("Index");
        }

    }
}
