using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ContactComponent
{
    public class SendMessage : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ContactComponent/SendMessage.cshtml");
        }
    }
}
