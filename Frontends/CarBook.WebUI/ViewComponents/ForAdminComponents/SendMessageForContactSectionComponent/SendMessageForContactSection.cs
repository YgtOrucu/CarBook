using CarBook.Dto.Dtos.ForAdminPageDtos.ContactSectionDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForAdminComponents.SendMessageForContactSectionComponent
{
    public class SendMessageForContactSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForAdminComponents/SendMessageForContactSectionComponent/SendMessageForContactSection.cshtml", new SendMailDto());
        }
    }
}
