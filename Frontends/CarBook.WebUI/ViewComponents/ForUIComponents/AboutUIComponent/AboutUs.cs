using CarBook.Dto.Dtos.AboutSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.AboutUIComponent
{
    public class AboutUs(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("about");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/AboutUIComponent/AboutUs.cshtml", value);
            }

            return View("~/Views/Shared/Components/ForUIComponents/AboutUIComponent/AboutUs.cshtml");
        }
    }
}
