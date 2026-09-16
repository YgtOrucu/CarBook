using CarBook.Dto.Dtos.ForUsersPageDtos.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

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

        [HttpPost]
        public IActionResult RentACar(CreateReservationDto model)
        {
            var FullName = User.FindFirst("FullName")?.Value;
            var Email = User.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
            model.FullName = FullName;
            model.Email = Email;
            return RedirectToAction("Index", "HomePage", new { Area = "Users" });
        }
    }
}
