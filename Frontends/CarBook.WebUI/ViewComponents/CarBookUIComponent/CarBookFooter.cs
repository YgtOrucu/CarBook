using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarBookUIComponent
{
    public class CarBookFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/CarBookUIComponent/CarBookFooter.cshtml");
        }
    }
}
