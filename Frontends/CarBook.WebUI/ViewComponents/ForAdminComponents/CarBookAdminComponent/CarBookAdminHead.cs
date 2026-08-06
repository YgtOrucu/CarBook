using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForAdminComponents.CarBookAdminComponent
{
    public class CarBookAdminHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForAdminComponents/CarBookAdminComponent/CarBookAdminHead.cshtml");
        }
    }
}
