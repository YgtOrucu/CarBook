using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.AboutUIComponent
{
    public class BecomeADrive : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/AboutUIComponent/BecomeADrive.cshtml");
        }
    }
}
