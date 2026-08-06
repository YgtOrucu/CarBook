using CarBook.Dto.Dtos.ForUsersPageDtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class BlogDetailGetAuthorDetailsSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog/GetAuthorByBlogId?id={Id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<GetAuthorByBlogIdDto>();
                return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetailGetAuthorDetailsSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetailGetAuthorDetailsSection.cshtml", Id);
        }
    }
}