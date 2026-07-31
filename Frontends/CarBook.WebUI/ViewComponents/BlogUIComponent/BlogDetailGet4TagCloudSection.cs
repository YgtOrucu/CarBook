using CarBook.Dto.Dtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogUIComponent
{
    public class BlogDetailGet4TagCloudSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blogTag/GetTagByBlogId?id={Id}");
            if (response.IsSuccessStatusCode)
            { 
                var value = await response.Content.ReadFromJsonAsync<List<BlogDetailGet4TagCloudDto>>();
                return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGet4TagCloudSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGet4TagCloudSection.cshtml", Id);
        }
    }
}