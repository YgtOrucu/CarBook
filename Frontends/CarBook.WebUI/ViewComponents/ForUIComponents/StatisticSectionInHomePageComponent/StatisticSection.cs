using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.ForUIComponents.StatisticSectionInHomePageComponent
{
    public class StatisticSection : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/ForUIComponents/StatisticSectionInHomePageComponent/StatisticSection.cshtml");
        }
    }
}
