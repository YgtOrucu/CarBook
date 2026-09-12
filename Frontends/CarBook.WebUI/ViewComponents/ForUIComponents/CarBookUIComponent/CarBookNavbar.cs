using CarBook.Dto.Dtos.ForUsersPageDtos.NavbarDto;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarBookUIComponent
{
    public class CarBookNavbar : ViewComponent
    {
        public IViewComponentResult Invoke(CheckLoginUser checkLogin)
        {
            return View("~/Views/Shared/Components/ForUIComponents/CarBookUIComponent/CarBookNavbar.cshtml", checkLogin);
        }
    }
}
