using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
