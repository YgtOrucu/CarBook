using CarBook.Dto.Dtos.ForUsersPageDtos.BlogDetailSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class BlogDetailContentSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blogDetail/{Id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<ResultBlogDetail>();
                return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetailContentSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/BlogDetailContentSection.cshtml", Id);
        }
    }
}