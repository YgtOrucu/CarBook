using CarBook.Application.Base;
using CarBook.Dto.Dtos.AuthDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AuthController(IHttpClientFactory clientFactory) : Controller
    {
        private readonly HttpClient client = clientFactory.CreateClient("CarBookAPI");

        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var response = await client.PostAsJsonAsync("auth/register", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            await GetErrorMessage(response);
            return View(dto);
        }

        private async Task GetErrorMessage(HttpResponseMessage response)
        {
            var result = await response.Content.ReadFromJsonAsync<BaseResult<GetApıErrors>>();
            if (result?.Errors != null)
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.ErrorMessage ?? "An error occurred.");
                }
            }
        }

        #endregion
    }
}
