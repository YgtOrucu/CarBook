using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForAdminComponents.CarBookAdminComponent
{
    public class CarBookAdminFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForAdminComponents/CarBookAdminComponent/CarBookAdminFooter.cshtml");
        }
    }
}
