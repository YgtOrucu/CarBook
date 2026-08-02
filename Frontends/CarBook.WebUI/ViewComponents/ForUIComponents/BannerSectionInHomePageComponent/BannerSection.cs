using CarBook.Dto.Dtos.BannerSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BannerSectionInHomePageComponent
{
    public class BannerSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("banner");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultBannerDto>();
                return View("~/Views/Shared/Components/ForUIComponents/BannerSectionInHomePageComponent/BannerSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/ForUIComponents/BannerSectionInHomePageComponent/BannerSection.cshtml");
        }
    }
}
