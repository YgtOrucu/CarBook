using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Users.Controllers
{
    [Area("Users")]
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CarDetails(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
