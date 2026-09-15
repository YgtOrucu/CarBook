using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ContactComponent
{
    public class SendMessage : ViewComponent
    {
        public IViewComponentResult Invoke(string? Name, string? Email)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            return View("~/Views/Shared/Components/ForUIComponents/ContactComponent/SendMessage.cshtml");
        }
    }
}
