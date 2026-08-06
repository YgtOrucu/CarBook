using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
