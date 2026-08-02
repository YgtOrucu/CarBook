using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ContactComponent
{
    public class SendMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/ContactComponent/SendMessage.cshtml");
        }
    }
}
