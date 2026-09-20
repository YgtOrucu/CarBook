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
    }
}
