using CarBook.Dto.Dtos.ForAdminPageDtos.FooterAddressSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterAddressController(IHttpClientFactory httpClientFactory) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"footerAddress");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultFooterAddressDto>();
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateFooterAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("footerAddress", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"footerAddress/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateFooterAddressDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("footerAddress", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"footerAddress/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
