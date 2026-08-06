using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class BlogController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            ViewBag.Page = page;
            return View();
        }

        public IActionResult BlogDetail(int id)
        {
            ViewBag.id = id;
            return View();
        }
    }
}
