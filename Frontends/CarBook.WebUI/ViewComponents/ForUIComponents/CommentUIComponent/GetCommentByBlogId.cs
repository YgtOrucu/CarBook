using CarBook.Dto.Dtos.CommentSectionDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CommentUIComponent
{
    public class GetCommentByBlogId(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"comment/GetCommentByBlogId?BlogId={Id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<GetCommentByBlogIdDto>>();
                return View("~/Views/Shared/Components/ForUIComponents/CommentUIComponent/GetCommentByBlogId.cshtml", value);
            }
            return View("~/Views/Shared/Components/ForUIComponents/CommentUIComponent/GetCommentByBlogId.cshtml", Id);
        }
    }
}
