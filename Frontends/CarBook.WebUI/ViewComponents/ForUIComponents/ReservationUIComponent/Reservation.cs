using CarBook.Application.Base;
using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ServicesUIComponent
{
    public class Reservation(IHttpClientFactory clientFactory) : ViewComponent
    {
        private readonly HttpClient client = clientFactory.CreateClient("CarBookAPI");
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await client.GetAsync("reservation/ReservationFormValues");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<BaseResult<GetReservationFormValuesDto>>();
                ViewBag.Car = value!.Data!.Cars;
                ViewBag.PickUpLocation = value!.Data!.PickUpLocations;
                ViewBag.DropOffLocation = value!.Data!.DropOffLocations;
            }
            else
            {
                ViewBag.Car = new List<GetCarDropdownDto>();
                ViewBag.PickUpLocation = new List<GetLocationDropdownDto>();
                ViewBag.DropOffLocation = new List<GetLocationDropdownDto>();
            }
            return View("~/Views/Shared/Components/ForUIComponents/ReservationUIComponent/Reservation.cshtml");
        }
    }
}
