using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CarBookUIComponent
{
    public class CarBookScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/CarBookUIComponent/CarBookScript.cshtml");
        }
    }
}
