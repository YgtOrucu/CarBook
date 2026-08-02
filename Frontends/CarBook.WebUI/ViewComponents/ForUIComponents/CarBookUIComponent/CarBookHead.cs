using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.CarBookUIComponent
{
    public class CarBookHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/CarBookUIComponent/CarBookHead.cshtml");
        }
    }
}
