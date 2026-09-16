using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.ServicesUIComponent
{
    public class Reservation() : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/ReservationUIComponent/Reservation.cshtml");
        }
    }
}
