using CarBook.Dto.Dtos.BlogSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.BlogUIComponent
{
    public class Blog(IHttpClientFactory httpClientFactory) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {
            int pageSize = 5;
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync("blog");

            if (response.IsSuccessStatusCode)
            {
                var values = await response.Content.ReadFromJsonAsync<List<ResultBlogDto>>();

                int totalCount = values!.Count;
                int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                if (page < 1) page = 1;
                if (page > totalPages && totalPages > 0) page = totalPages;

                var paginatedValues = values
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = totalPages;

                return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/Blog.cshtml", paginatedValues);
            }

            return View("~/Views/Shared/Components/ForUIComponents/BlogUIComponent/Blog.cshtml", new List<ResultBlogDto>());
        }
    }
}