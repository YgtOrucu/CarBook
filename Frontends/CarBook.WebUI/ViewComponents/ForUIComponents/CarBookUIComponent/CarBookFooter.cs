using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarBookUIComponent
{
    public class CarBookFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/CarBookUIComponent/CarBookFooter.cshtml");
        }
    }
}
