using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarBookUIComponent
{
    public class CarBookNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/CarBookUIComponent/CarBookNavbar.cshtml");
        }
    }
}
