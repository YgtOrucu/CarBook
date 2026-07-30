using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.StatisticSectionInHomePageComponent
{
    public class StatisticSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/StatisticSectionInHomePageComponent/StatisticSection.cshtml");
        }
    }
}
