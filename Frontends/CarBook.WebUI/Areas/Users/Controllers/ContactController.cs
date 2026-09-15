using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.ContactSectionDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
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
                TempData["SuccessMessage"] = "Mesajınız iletilmiştir.En yakın zaman da iletişime geçilecektir.";
                return RedirectToAction("Index");
            }
            var errormessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();

            if (errormessage != null)
            {
                foreach (var error in errormessage.Errors!)
                {
                    TempData["ErrorMessage"] = error.ErrorMessage;
                    return RedirectToAction("Index");
                }
            }
            TempData["ErrorMessage"] = "Mesaj İletilmedi.Lütfen tekrar deneyiniz";
            return RedirectToAction("Index");
        }
    }
}
