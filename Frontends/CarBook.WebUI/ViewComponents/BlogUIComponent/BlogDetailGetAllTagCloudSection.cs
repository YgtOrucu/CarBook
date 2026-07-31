using CarBook.Dto.Dtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogUIComponent
{
    public class BlogDetailGetAllTagCloudSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blogTag/GetTagAll?id={Id}");
            if (response.IsSuccessStatusCode)
            { 
                var value = await response.Content.ReadFromJsonAsync<List<BlogDetailGet4TagCloudDto>>();
                return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGetAllTagCloudSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGetAllTagCloudSection.cshtml", Id);
        }
    }
}