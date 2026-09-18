using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class CarController(IHttpClientFactory clientFactory) : Controller
    {
        private readonly HttpClient client = clientFactory.CreateClient("CarBookAPI");
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CarDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RentACar(CreateReservationDto model)
        {
            var FullName = User.FindFirst("FullName")?.Value;
            var Email = User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
            model.FullName = FullName;
            model.Email = Email;

            var response = await client.PostAsJsonAsync("reservation", model);

            if (response.IsSuccessStatusCode)
            {
                var successResult = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
                TempData["SuccessMessage"] = successResult?.Message ?? "Rezervasyonunuz alınmıştır. En kısa zamanda bilgilendirileceksiniz.";
            }
            else
            {          
                try
                {
                    var errormessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();

                    if (errormessage?.Errors != null && errormessage.Errors.Any())
                    {
                        foreach (var error in errormessage.Errors)
                        {
                            TempData["ErrorMessage"] = error.ErrorMessage;
                            break;
                        }
                    }
                    else if (!string.IsNullOrEmpty(errormessage?.Message))
                    {
                        TempData["ErrorMessage"] = errormessage.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Seçilen araç, belirtilen tarih ve saat aralığında dolu veya bir hata oluştu.";
                    }
                }
                catch
                {
                    var rawError = await response.Content.ReadAsStringAsync();
                    TempData["ErrorMessage"] = !string.IsNullOrEmpty(rawError) ? rawError : "Rezervasyon yapılırken beklenmeyen bir hata oluştu.";
                }
            }

            return RedirectToAction("Index", "HomePage", new { Area = "Users" });
        }
    }
}
