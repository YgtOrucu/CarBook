using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.AboutUIComponent
{
    public class BecomeADrive : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/AboutUIComponent/BecomeADrive.cshtml");
        }
    }
}
