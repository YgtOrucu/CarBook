using CarBook.Dto.Dtos.CarSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarsUIComponent
{
    public class GetCarsLastest5(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("car/GetCarLastest5ForPresantation");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultCarLastest5Dto>>();
                return View("~/Views/Shared/Components/CarsUIComponent/GetCarsLastest5.cshtml", value);
            }

            return View("~/Views/Shared/Components/CarsUIComponent/GetCarsLastest5.cshtml");
        }
    }
}
