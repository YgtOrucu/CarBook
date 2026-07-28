using CarBook.Dto.Dtos.ContactSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ContactController(IHttpClientFactory httpClientFactory) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("contact", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Mesajınız iletilmiştir.En yakın zaman da iletişime geçilecektir.s";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Mesaj İletilmedi.Lütfen tekrar deneyiniz";
            return RedirectToAction("Index");
        }
    }
}
