using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarBookUIComponent
{
    public class CarBookNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/CarBookUIComponent/CarBookNavbar.cshtml");
        }
    }
}
