using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.AskAssistantDto;
using CarBook.Dto.Dtos.ForUsersPageDtos.CommentSectionDto;
using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class AccountController(IHttpClientFactory clientFactory, IHttpContextAccessor httpContext) : Controller
    {
        private readonly HttpClient client = clientFactory.CreateClient("CarBookAPI");
        private readonly string userEmail = httpContext.HttpContext?.User?.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

        #region MyReservationProcess
        public async Task<IActionResult> MyReservations()
        {
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

        #region MyComments

        public async Task<IActionResult> MyComments()
        {
            var response = await client.GetAsync($"comment/GetLoginUsersComments/{userEmail}");

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<List<GetLoginUsersComments>>>();
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
        public async Task<IActionResult> DeleteComment(int Id)
        {
            var response = await client.DeleteAsync($"comment/DeleteCommentForUser/{Id}");

            if (response.IsSuccessStatusCode)
            {
                return Json(new { isSuccess = true, message = "Yorum başarıyla silindi." });
            }

            return BadRequest(new { isSuccess = false, message = "Yorum silinirken bir hata oluştu." });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto model)
        {
            var response = await client.PutAsJsonAsync("comment/UpdateCommentForUser", model);
            if (response.IsSuccessStatusCode)
                return Ok(new { message = "Yorum başarıyla güncellendi." });

            return StatusCode(500, new { message = "Güncelleme sırasında sunucu hatası oluştu." });
        }
        #endregion

        #region MyAssistant
        [HttpGet]
        public IActionResult MyAssistant()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AskAssistant([FromBody] AskAssistantDto model)
        {
            var response = await client.PostAsJsonAsync("assistant/ask", model);

            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<AssistantAnswerDto>>();
                return Ok(new { message = value!.Data!.Answer });
            }

            return StatusCode(500, new { message = "Yapay zeka asistanına ulaşılırken bir hata oluştu." });
        }
        #endregion
    }
}
