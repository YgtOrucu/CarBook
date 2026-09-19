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
            var Phone = User.FindFirst(JwtRegisteredClaimNames.PhoneNumber)?.Value;
            model.FullName = FullName;
            model.Email = Email;
            model.PhoneNumber = Phone;

            var response = await client.PostAsJsonAsync("reservation", model);

            if (response.IsSuccessStatusCode)
            {
                var successResult = await response.Content.ReadFromJsonAsync<BaseResult<object>>();
                TempData["SuccessMessage"] = successResult?.Message ?? "Rezervasyon başarıyla oluşturuldu. En kısa zamanda sizinle iletişime geçilecektir.";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    var errorMessage = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();

                    if (errorMessage?.Errors != null && errorMessage.Errors.Any())
                    {
                        TempData["ErrorMessage"] = errorMessage.Errors.First().ErrorMessage;
                    }
                    else if (!string.IsNullOrWhiteSpace(errorMessage?.Message))
                    {
                        TempData["ErrorMessage"] = errorMessage.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Girdiğiniz bilgileri lütfen kontrol ediniz.";
                    }
                }
                catch
                {
                    TempData["ErrorMessage"] = "Lütfen form alanlarını kontrol edip tekrar deneyiniz.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "İşlem sırasında teknik bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
            }

            return RedirectToAction("Index", "HomePage", new { Area = "Users" });
        }
    }
}
