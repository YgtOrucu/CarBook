using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.CarSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarsUIComponent
{
    public class CarDetails(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"car/Cardetails/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<GetCarDetailByCarIdDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/CarsUIComponent/CarDetails.cshtml", value?.Data);
            }

            return View("~/Views/Shared/Components/ForUIComponents/CarsUIComponent/CarDetails.cshtml");
        }
    }
}
