using CarBook.Dto.Dtos.ForUsersPageDtos.BlogSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class GetLastest5BlogSection(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog/Lastest5ForPresantationPage");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultBlogForPresantationPageDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/GetLastest5BlogSection.cshtml", value);
            }
            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/GetLastest5BlogSection.cshtml");
        }
    }
}