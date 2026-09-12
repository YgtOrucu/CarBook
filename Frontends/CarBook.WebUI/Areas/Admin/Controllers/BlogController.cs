using CarBook.Dto.Dtos.ForAdminPageDtos.BlogSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController(IHttpClientFactory httpClientFactory) : AdminBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<List<ResultBlogDto>>();
                return View(value);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            ViewBag.Author = await GetAuthor();
            ViewBag.Category = await GetCategory();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PostAsJsonAsync("blog", dto);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            ViewBag.Author = await GetAuthor();
            ViewBag.Category = await GetCategory();
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadFromJsonAsync<UpdateBlogDto>();
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.PutAsJsonAsync("blog", dto);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

        public async Task<IActionResult> RemoveBlog(int id)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.DeleteAsync($"blog/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GenerateBlogWithAI([FromBody] AIGenerateRequestForCreateBlogDto request)
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"blog/AnswerOpenAI/{request.CategoryName}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AIGenerateResponseDto>();
                return Json(new { success = true, title = result.Title, description = result.Description });
            }

            return Json(new { success = false, message = "AI içeriği üretilirken bir hata oluştu." });
        }

        private async Task<dynamic> GetCategory()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"category");
            var value = await response.Content.ReadFromJsonAsync<List<GetCategoryForCreateAndUpdateBlog>>();
            return value!;
        }

        private async Task<dynamic> GetAuthor()
        {
            var client = httpClientFactory.CreateClient("CarBookAPI");
            var response = await client.GetAsync($"author");
            var value = await response.Content.ReadFromJsonAsync<List<GetAuthorForCreateAndUpdateBlog>>();
            return value!;

        }
    }
}
