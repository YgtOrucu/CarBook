using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForAdminPageDtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController(IHttpClientFactory httpClientFactory) : Controller
    {
        private readonly HttpClient client = httpClientFactory.CreateClient("CarBookAPI");

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync($"Reservation");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<List<ResultReservationDto>>>();
                return View(value!.Data);
            }
            return View();
        }

    }
}
