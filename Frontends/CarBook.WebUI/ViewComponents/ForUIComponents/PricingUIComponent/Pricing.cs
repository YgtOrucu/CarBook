using CarBook.Dto.Dtos.CarPricingSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.PricingUIComponent
{
    public class Pricing(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("carPricing");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultCarPricingDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/PricingUIComponent/Pricing.cshtml", value);
            }

            return View("~/Views/Shared/Components/ForUIComponents/PricingUIComponent/Pricing.cshtml");
        }
    }
}
