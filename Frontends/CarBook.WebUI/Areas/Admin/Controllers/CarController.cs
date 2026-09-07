using CarBook.Dto.Dtos.ForAdminPageDtos.BrandSectionDtos;
using CarBook.Dto.Dtos.ForAdminPageDtos.CarSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController(IHttpClientFactory httpClientFactory) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("car/getBrand");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultCarDto>>();
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            ViewBag.BrandValues = await GetBrandList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("Car", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.BrandValues = await GetBrandList();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            ViewBag.BrandValues = await GetBrandList();
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"Car/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateCarDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("Car", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ViewBag.BrandValues = await GetBrandList();
            return View(dto);
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"Car/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }

        private async Task<List<ResultBrandDto>> GetBrandList()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("brand");
            if (response.IsSuccessStatusCode)
            {
                var values = await response.Content.ReadFromJsonAsync<List<ResultBrandDto>>();
                return values;
            }
            return null;
        }
    }
}