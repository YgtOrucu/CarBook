using CarBook.Dto.Dtos.BlogSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.BlogUIComponent
{
    public class BlogDetailGetBlogCountByCategory(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog/GetBlogCountByCategory");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<GetBlogCountByCategoryDto>>();
                return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGetBlogCountByCategory.cshtml", value);
            }
            return View("~/Views/Shared/Components/BlogUIComponent/BlogDetailGetBlogCountByCategory.cshtml");
        }
    }
}
