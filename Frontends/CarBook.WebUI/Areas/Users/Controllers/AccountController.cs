using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class AccountController(IHttpClientFactory clientFactory) : Controller
    {
        private readonly HttpClient client = clientFactory.CreateClient("CarBookAPI");

        #region MyReservationProcess
        public async Task<IActionResult> MyReservations()
        {
            var userEmail = User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
            var response = await client.GetAsync($"reservation/GetLoginUsersReservation/{userEmail}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<List<GetLoginUsersReservation>>>();
                return View(value!.Data);
            }
            var errormessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();

            if (errormessage != null)
            {
                foreach (var error in errormessage.Errors!)
                {
                    TempData["ErrorMessage"] = error.ErrorMessage;
                    return RedirectToAction("Index", "HomePage", new { Area = "Users" });
                }
            }
            return RedirectToAction("Index", "HomePage", new { Area = "Users" });
        }

        [HttpPost]
        public async Task<IActionResult> CancelReservation(int Id)
        {
            var response = await client.DeleteAsync($"reservation/{Id}");

            if (response.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true, message = "Rezervasyon başarıyla iptal edildi." });
            }

            return BadRequest(new { isSuccess = false, message = "Rezervasyon iptal edilirken bir hata oluştu." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationDto model)
        {
            var response = await client.PutAsJsonAsync($"reservation/UpdateReservation", model);
            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Rezervasyon başarıyla güncellendi." });

            return StatusCode(500, new { message = "Güncelleme sırasında sunucu hatası oluştu:" });
        }

        #endregion
    }
}
