using CarBook.Dto.Dtos.ForAdminPageDtos.AuthorSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController(IHttpClientFactory httpClientFactory) : AdminBaseController
    {
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"author");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultAuthorDto>>();
                return View(value);
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("author", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"author/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateAuthorDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("author", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"author/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
