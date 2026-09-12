using CarBook.Dto.Dtos.ForAdminPageDtos.AboutSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController(IHttpClientFactory httpClientFactory) : AdminBaseController
    {
        private readonly HttpClient client = httpClientFactory.CreateClient("CarBookAPI");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync($"about");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
                return View(value);
            }
            return View(new List<ResultAboutDto>());
        }

        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            var response = await client.PostAsJsonAsync("about", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var response = await client.GetAsync($"about/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateAboutDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            var response = await client.PutAsJsonAsync("about", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveAbout(int id)
        {
            var response = await client.DeleteAsync($"about/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
