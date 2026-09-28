using CarBook.Application.Base;
using CarBook.Domain.Entities.Enums;
using CarBook.Dto.Dtos.ForAdminPageDtos.ReservationDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient client = httpClientFactory.CreateClient("CarBookAPI");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync($"Reservation");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<List<ResultReservationDto>>>();
                return View(value!.Data);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateAIMessage([FromBody] GenerateReservationMessageDto model)
        {
            var response = await client.PostAsJsonAsync("Reservation/GenerateMessage", model);

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<GeneratedMessageDto>>();
                return Json(new { success = true, reply = value!.Data!.Message });
            }

            var errorMessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();
            var msg = errorMessage?.Errors?.FirstOrDefault()?.ErrorMessage ?? "Yapay zeka yanıt üretirken bir hata oluştu.";

            return Json(new { success = false, message = msg });
        }

        [HttpPost]
        public async Task<IActionResult> SendReservationEmail(string email, string message, int Id, ReservationStatus Status)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                return Json(new { success = false, message = "E-posta veya mesaj içeriği boş olamaz." });
            }

            var payload = new SendReservationEmailDto { Email = email, Message = message, Id = Id, Status = Status };
            var response = await client.PostAsJsonAsync("Reservation/SendEmail", payload);

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Bilgilendirme e-postası başarıyla gönderildi." });
            }

            var errorMessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();
            var msg = errorMessage?.Errors?.FirstOrDefault()?.ErrorMessage ?? "E-posta gönderilirken bir hata oluştu.";

            return Json(new { success = false, message = msg });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var response = await client.DeleteAsync($"Reservation/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Rezervasyon başarıyla silindi.";
            }
            else
            {
                var errorMessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();
                TempData["ErrorMessage"] = errorMessage?.Errors?.FirstOrDefault()?.ErrorMessage ?? "Rezervasyon silinirken bir hata oluştu.";
            }

            return RedirectToAction("Index");
        }

    }
}
