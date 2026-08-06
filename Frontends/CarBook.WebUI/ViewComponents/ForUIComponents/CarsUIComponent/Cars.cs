using CarBook.Dto.Dtos.ForUsersPageDtos.CarSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarsUIComponent
{
    public class Cars(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("car/GetCarForPresantation");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultCarDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/CarsUIComponent/Cars.cshtml", value);
            }

            return View("~/Views/Shared/Components/ForUIComponents/CarsUIComponent/Cars.cshtml");
        }
    }
}
