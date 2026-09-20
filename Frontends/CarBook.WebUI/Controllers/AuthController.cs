using CarBook.Application.Base;
using CarBook.Dto.Dtos.AuthDtos;
using CarBook.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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


        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await client.PostAsJsonAsync("auth/login", dto);
            if (!response.IsSuccessStatusCode)
            {
                await GetErrorMessage(response);
                return View(dto);
            }


            var result = await response.Content.ReadFromJsonAsync<GetJwtTokenInfo>();
            if (result?.Data?.Token != null)
            {
                var tokenString = result.Data.Token;
                var expirationTime = result.Data.ExpirationTime;
                var handler = new JwtSecurityTokenHandler();
                var jwtTokenDetails = handler.ReadJwtToken(tokenString);


                var claims = jwtTokenDetails.Claims.ToList();

                claims.Add(new Claim("AccessToken", tokenString));


                var claimsIdentity = new ClaimsIdentity
                (
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    nameType: JwtRegisteredClaimNames.UniqueName,
                    roleType: "role"
                );

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = expirationTime
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                var userRole = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role || x.Type == "role")?.Value;

                if (userRole == "Admin")
                    return RedirectToAction("Index", "About", new { Area = "Admin" });

                return RedirectToAction("Index", "HomePage", new { Area = "Users" });
            }
            return View(dto);
        }
        #endregion

        #region ForgotPassword
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            TempData["Email"] = dto.Email;
            var response = await client.PostAsJsonAsync("auth/forgotpassword", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("ResetPassword");

            await GetErrorMessage(response);
            return View(dto);
        }
        #endregion

        #region ResetPassword
        [HttpGet]
        public IActionResult ResetPassword()
        {
            if (TempData["Email"] != null)
                ViewBag.Email = TempData["Email"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            var response = await client.PostAsJsonAsync("auth/resetpassword", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            await GetErrorMessage(response);
            return View(dto);
        }
        #endregion

        #region Logout

        public async Task<IActionResult> Logout()
        {
            var token = User.FindFirst("AccessToken")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            await client.PostAsync("auth/logout", null);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "HomePage", new { Area = "Users" });
        }

        #endregion

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
    }
}
