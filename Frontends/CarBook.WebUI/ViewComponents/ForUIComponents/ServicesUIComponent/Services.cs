using CarBook.Dto.Dtos.ForUsersPageDtos.ServicesSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ServicesUIComponent
{
    public class Services(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("services/Lastest5Services");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultServiceDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/ServicesUIComponent/Services.cshtml", value);
            }

            return View("~/Views/Shared/Components/ForUIComponents/ServicesUIComponent/Services.cshtml");
        }
    }
}
