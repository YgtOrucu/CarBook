using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarBookUIComponent
{
    public class CarBookHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/CarBookUIComponent/CarBookHead.cshtml");
        }
    }
}
