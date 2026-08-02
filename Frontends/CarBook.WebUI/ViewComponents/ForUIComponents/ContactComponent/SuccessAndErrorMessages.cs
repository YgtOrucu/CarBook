using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ContactComponent
{
    public class SuccessAndErrorMessages : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (TempData["SuccessMessage"] != null)
                ViewBag.SuccessMessage = TempData["SuccessMessage"]!.ToString();

            if (TempData["ErrorMessage"] != null)
                ViewBag.ErrorMessage = TempData["ErrorMessage"]!.ToString();
            return View("~/Views/Shared/Components/ForUIComponents/ContactComponent/SuccessAndErrorMessages.cshtml");
        }
    }
}
