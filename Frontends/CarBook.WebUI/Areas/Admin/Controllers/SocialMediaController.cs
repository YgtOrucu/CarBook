using CarBook.Dto.Dtos.ForAdminPageDtos.SocialMediaSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController(IHttpClientFactory httpClientFactory) : AdminBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"socialMedia");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultSocialMediaDto>>();
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("socialMedia", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"SocialMedia/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateSocialMediaDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("socialMedia", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"socialMedia/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
