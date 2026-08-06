using CarBook.Dto.Dtos.ForUsersPageDtos.CommentSectionDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class CommentController(IHttpClientFactory httpClientFactory) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommmentDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("comment", dto);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Mesajınız iletilmiştir.En yakın zaman da iletişime geçilecektir.";
                return RedirectToAction("BlogDetail", "Blog", new { id = dto.BlogId });
            }
            TempData["ErrorMessage"] = "Mesaj İletilmedi.Lütfen tekrar deneyiniz";
            return RedirectToAction("BlogDetail", "Blog", new { id = dto.BlogId });
        }
    }
}
