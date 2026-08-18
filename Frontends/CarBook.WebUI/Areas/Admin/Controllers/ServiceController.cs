using CarBook.Dto.Dtos.ForAdminPageDtos.ServiceSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController(IHttpClientFactory httpClientFactory) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"services");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultServiceDto>>();
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("services", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"services/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateServiceDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("services", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveService(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"services/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
